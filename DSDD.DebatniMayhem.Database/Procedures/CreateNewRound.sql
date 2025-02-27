CREATE PROCEDURE [dbo].[CreateNewRound]
	@Topic VARCHAR(max),
	@InfoSlide VARCHAR(max) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	/* STAGE 1: Nalezení aktivních hráčů a co můžou hrát */

	DECLARE @Players TABLE 
	(
		PlayerId INT NOT NULL, 
		OG_Played BIT NOT NULL,
		OO_PLayed BIT NOT NULL,
		CG_Played BIT NOT NULL, 
		CO_Played BIT NOT NULL,
		UnplayedPositions INT NOT NULL
	)
	INSERT INTO @Players 
	SELECT PlayerId, OG_Played, OO_PLayed, CG_Played, CO_Played, UnplayedPositions  
	FROM GetActivePlayersPositionHistory()
			
	DECLARE @PlayerCount INT = (SELECT COUNT(PlayerId) FROM @Players);
	DECLARE @MatchesCount INT = @PlayerCount / 8;
	
	IF @PlayerCount = 0
	BEGIN
		RAISERROR('Nejsou žádní aktivní hráči!', 16, 1);
		RETURN
	END

	IF @PlayerCount % 8 <> 0
	BEGIN
		RAISERROR('Počet aktivních hráčů musí být dělitelný 8!', 16, 1);
		RETURN
	END

	DECLARE @Rooms TABLE (RoomId INT)
	INSERT INTO @Rooms SELECT Id FROM Rooms WHERE Active = 1

	IF @MatchesCount > (SELECT COUNT(RoomId) FROM @Rooms)
	BEGIN
		RAISERROR('Není dostatečný počet aktivních místností pro toto kolo!', 16, 1);
		RETURN
	END
	
	/* STAGE 2: Vygenerování všech slotu v počtu napříč celým kolem */

	DECLARE @AvailableSlots TABLE (Slot VARCHAR(4));
	INSERT INTO @AvailableSlots 
	SELECT Slot FROM GetAvailableSlotsForRound(@PlayerCount)
	ORDER BY NEWID()
		
	/* STAGE 3: Přířazení hráčů ke slotům které ještě nehrály, popř. náhodně */

	DECLARE @PlayerSlots TABLE (PlayerId INT, Slot VARCHAR(4))

	DECLARE @Player_PlayerId INT
	DECLARE @Player_OG_Played BIT
	DECLARE @Player_OO_PLayed BIT
	DECLARE @Player_CG_Played BIT
	DECLARE @Player_CO_Played BIT

	-- Hráči se prohledávají od těch kterému zbývá 1 slot (Funkce GetActivePlayersPositionHistory vrací 1,2,3,4. nemůže být 0, vrací se na 4)
	-- Dání priority hráči s nižším počtem volných slotů zajistí vyšší férovost
	DECLARE PlayersCursor CURSOR FOR
	SELECT PlayerId, OG_Played, OO_PLayed, CG_Played, CO_Played FROM @Players
	ORDER BY UnplayedPositions ASC, NEWID()

	OPEN PlayersCursor

	WHILE 1=1
	BEGIN
		FETCH NEXT FROM PlayersCursor INTO @Player_PlayerId, @Player_OG_Played, @Player_OO_PLayed, @Player_CG_Played, @Player_CO_Played

		IF @@FETCH_STATUS <> 0
			BREAK

		-- Najde první slot který hráč ještě nehrál
		DECLARE @TakesSlot VARCHAR(4) = (
			SELECT TOP 1 Slot FROM @AvailableSlots
			WHERE (Slot IN ('OG_1', 'OG_2') AND @Player_OG_Played = 0)
			OR (Slot IN ('OO_1', 'OO_2') AND @Player_OO_Played = 0)
			OR (Slot IN ('CG_1', 'CG_2') AND @Player_CG_Played = 0)
			OR (Slot IN ('CO_1', 'CO_2') AND @Player_CO_Played = 0)
		)

		-- Může nastat situace kdy hráč může mít např jen OG ale OG sloty už nejsou volné. Poté dostane jiný slot random.
		-- Funkce GetActivePlayersPositionHistory by i tak měla v dalším kole nabídnout OG slot jako volný. TODO: Unit test
		IF @TakesSlot IS NULL
			SET @TakesSlot = (SELECT TOP 1 Slot FROM @AvailableSlots)

		DELETE TOP(1) FROM @AvailableSlots WHERE Slot = @TakesSlot

		INSERT INTO @PlayerSlots (PlayerId, Slot) VALUES (@Player_PlayerId, @TakesSlot)
	END
		
	CLOSE PlayersCursor
	DEALLOCATE PlayersCursor
	
	/* STAGE 4: Rozřazení hráčů do debat podale jejich slotů */

	DECLARE @Matches TABLE (RoomId INT, OG_1 INT, OG_2 INT, OO_1 INT, OO_2 INT, CG_1 INT, CG_2 INT, CO_1 INT, CO_2 INT)

	DECLARE @CurrentMatchIndex INT = 0;

	WHILE @CurrentMatchIndex < @MatchesCount
	BEGIN
		DECLARE @RoomId INT = (SELECT TOP(1) RoomId FROM @Rooms ORDER BY NEWID())

		-- každá místnost max 1x
		DELETE FROM @Rooms WHERE RoomId = @RoomId

		DECLARE @OG_1 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'OG_1')
		DECLARE @OG_2 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'OG_2')
		DECLARE @OO_1 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'OO_1')
		DECLARE @OO_2 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'OO_2')
		DECLARE @CG_1 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'CG_1')
		DECLARE @CG_2 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'CG_2')
		DECLARE @CO_1 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'CO_1')
		DECLARE @CO_2 INT = (SELECT TOP(1) PlayerId FROM @PlayerSlots WHERE Slot = 'CO_2')

		-- každý hrýč je v PlayerSlots nejvýše 1x
		DELETE FROM @PlayerSlots WHERE PlayerId IN (@OG_1, @OG_2, @OO_1, @OO_2, @CG_1, @CG_2, @CO_1, @CO_2)

		INSERT INTO @Matches (RoomId, OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2)
		VALUES (@RoomId, @OG_1, @OG_2, @OO_1, @OO_2, @CG_1, @CG_2, @CO_1, @CO_2)

		SET @CurrentMatchIndex = @CurrentMatchIndex + 1
	END
		
	/* STAGE 4: Vytvoření kola a jednotlivých debat */

	BEGIN TRY
		BEGIN TRANSACTION

		INSERT INTO Rounds (Topic, InfoSlide) VALUES (@Topic, @InfoSlide)
		
		DECLARE @RoundId INT = (SELECT MAX(Id) FROM Rounds)

		INSERT INTO Matches (RoundId, RoomId, OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2)
		SELECT @RoundId, RoomId, OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2
		FROM @Matches

		COMMIT TRANSACTION

		RETURN @RoundId
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
END