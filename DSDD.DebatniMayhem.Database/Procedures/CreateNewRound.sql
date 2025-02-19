CREATE OR ALTER PROCEDURE [dbo].[CreateNewRound]
	@Topic VARCHAR(max),
	@InfoSlide VARCHAR(max)
AS
BEGIN
	SET NOCOUNT ON
	
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
	
	IF @PlayerCount = 0
	BEGIN
		-- Throw an error if the count is not divisible by 8
		RAISERROR('There are no active players!', 16, 1);
		RETURN
	END

	IF @PlayerCount % 8 <> 0
	BEGIN
		-- Throw an error if the count is not divisible by 8
		RAISERROR('Number of active players must be divisible by 8!', 16, 1);
		RETURN
	END

	DECLARE @AvailableSlots TABLE (Slot VARCHAR(4));
	INSERT INTO @AvailableSlots 
	SELECT Slot FROM GetAvailableSlotsForRound(@PlayerCount) 
	-- Pořadí slotu je náhodně promícháno, jinak by byly by-default přidělovány v pořadí OG_1, OG_2 apod... v cyklu níže
	ORDER BY NEWID()

	DECLARE @PlayerSlots TABLE (PlayerId INT, Slot VARCHAR(4))

	DECLARE @Player_PlayerId INT
	DECLARE @Player_OG_Played BIT
	DECLARE @Player_OO_PLayed BIT
	DECLARE @Player_CG_Played BIT
	DECLARE @Player_CO_Played BIT

	-- Hráči se prohledávají od těch kterému zbývá 1 slot (možnosti jsou 1,2,3,4. nemůže být 0, vrací se na 4)
	-- Dání priority hráči s nižším počtem volných slotů zajistí vyšší férovost
	DECLARE PlayersCursor CURSOR FOR
	SELECT PlayerId, OG_Played, OO_PLayed, CG_Played, CO_Played FROM @Players
	ORDER BY UnplayedPositions ASC

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
			AND (Slot IN ('OO_1', 'OO_2') AND @Player_OO_Played = 0)
			AND (Slot IN ('CG_1', 'CG_2') AND @Player_CG_Played = 0)
			AND (Slot IN ('CO_1', 'CO_2') AND @Player_CO_Played = 0)
		)

		-- Může nastat situace kdy hráč může mít např jen OG ale OG sloty už nejsou volné. Poté dostane slot random.
		IF @TakesSlot IS NULL
			SET @TakesSlot = (SELECT TOP 1 Slot FROM @AvailableSlots)

		INSERT INTO @PlayerSlots (PlayerId, Slot) VALUES (@Player_PlayerId, @TakesSlot)
	END

	CLOSE PlayersCursor
	DEALLOCATE PlayersCursor

	DECLARE @Matches TABLE (OG_1 INT, OG_2 INT, OO_1 INT, OO_2 INT, CG_1 INT, CG_2 INT, CO_1 INT, CO_2 INT)

	WITH PlayerData AS (
		SELECT 
			PlayerId, 
			Slot
		FROM @PlayerSlots  -- Replace with actual table name
	)

	INSERT INTO @Matches
	SELECT 
		OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2
	FROM (
		SELECT PlayerId, Slot FROM PlayerData
		-- Náhodné rozřazení do debat
		ORDER BY NEWID()
	) AS SourceTable
	PIVOT (
		MAX(PlayerId) FOR Slot IN (OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2)
	) AS PivotTable;

	BEGIN TRY
		BEGIN TRANSACTION

		INSERT INTO Rounds (Topic, InfoSlide) VALUES (@Topic, @InfoSlide)
		
		DECLARE @RoundId INT = (SELECT MAX(Id) FROM Rounds)

		INSERT INTO Matches (RoundId, OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2)
		SELECT @RoundId, OG_1, OG_2, OO_1, OO_2, CG_1, CG_2, CO_1, CO_2
		FROM @Matches


		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
END