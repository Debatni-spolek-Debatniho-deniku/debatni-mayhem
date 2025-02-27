CREATE PROCEDURE [dbo].[ScoreMatch]
	@MatchId int,

	@OG_Points int,
	@OO_Points int,
	@CG_Points int,
	@CO_Points int,

	@OG_1_SpeakerPoints INT,
	@OG_2_SpeakerPoints INT,
	@OO_1_SpeakerPoints INT,
	@OO_2_SpeakerPoints INT,
	@CG_1_SpeakerPoints INT,
	@CG_2_SpeakerPoints INT,
	@CO_1_SpeakerPoints INT,
	@CO_2_SpeakerPoints INT
AS
BEGIN
	SET NOCOUNT ON

	/* STAGE 1: Validace */

	IF EXISTS (SELECT * FROM Matches WHERE Id = @MatchId AND (
			OG_Points IS NOT NULL OR
			OO_Points IS NOT NULL OR
			CG_Points IS NOT NULL OR
			CO_Points IS NOT NULL OR

			OG_1_SpeakerPoints IS NOT NULL OR
			OG_2_SpeakerPoints IS NOT NULL OR
			OO_1_SpeakerPoints IS NOT NULL OR
			OO_2_SpeakerPoints IS NOT NULL OR
			CG_1_SpeakerPoints IS NOT NULL OR
			CG_2_SpeakerPoints IS NOT NULL OR
			CO_1_SpeakerPoints IS NOT NULL OR
			CO_2_SpeakerPoints IS NOT NULL
		))
	BEGIN
		RAISERROR('Tato debata už má skóre!', 16, 1)
		RETURN
	END

	IF (@OG_Points < 0) OR (3 < @OG_Points)
	OR (@OO_Points < 0) OR (3 < @OO_Points)
	OR (@CG_Points < 0) OR (3 < @CG_Points)
	OR (@CO_Points < 0) OR (3 < @CO_Points)
	BEGIN
		RAISERROR('Body musí být mezi 0 a 3!', 16, 1)
		RETURN
	END

	DECLARE @PointsUnique BIT = (SELECT 
		CASE 
		WHEN @OG_Points <> @OO_Points 
			AND @OG_Points <> @CG_Points 
			AND @OG_Points <> @CO_Points 
			AND @OO_Points <> @CG_Points 
			AND @OO_Points <> @CO_Points 
			AND @CG_Points <> @CO_Points 
		THEN 1
		ELSE 0 
		END AS UniqueCheck)

	IF @PointsUnique = 0
	BEGIN
		RAISERROR('Nelze více týmům přiřadit stejné body!', 16, 1)
		RETURN
	END

	DECLARE @PointsSum INT = @OG_Points + @OO_Points + @CG_Points + @CO_Points;
	IF @PointsSum != 6
	BEGIN
		RAISERROR('Kontrolní součet bodů musí být 6!', 16, 1)
		RETURN
	END

	IF (@OG_1_SpeakerPoints < 60) OR (90 < @OG_1_SpeakerPoints)
	OR (@OG_2_SpeakerPoints < 60) OR (90 < @OG_2_SpeakerPoints)
	OR (@OO_1_SpeakerPoints < 60) OR (90 < @OO_1_SpeakerPoints)
	OR (@OO_2_SpeakerPoints < 60) OR (90 < @OO_2_SpeakerPoints)
	OR (@CG_1_SpeakerPoints < 60) OR (90 < @CG_1_SpeakerPoints)
	OR (@CG_2_SpeakerPoints < 60) OR (90 < @CG_2_SpeakerPoints)
	OR (@CO_1_SpeakerPoints < 60) OR (90 < @CO_1_SpeakerPoints)
	OR (@CO_2_SpeakerPoints < 60) OR (90 < @CO_2_SpeakerPoints)
	BEGIN
		RAISERROR('Body řečníků musí být mezi 60 a 90!', 16, 1)
		RETURN
	END

	/* STAGE 2: Načtení hráčů a jejich skóre */

	DECLARE @Found BIT;
	DECLARE @Match_OG_1 INT;
	DECLARE @Match_OG_2 INT;
	DECLARE @Match_OO_1 INT;
	DECLARE @Match_OO_2 INT;
	DECLARE @Match_CG_1 INT;
	DECLARE @Match_CG_2 INT;
	DECLARE @Match_CO_1 INT;
	DECLARE @Match_CO_2 INT;

	SELECT 
		@Match_CG_1 = CG_1,
		@Match_CG_2 = CG_2,
		@Match_CO_1 = CO_1,
		@Match_CO_2 = CO_2,
		@Match_OG_1 = OG_1,
		@Match_OG_2 = OG_2,
		@Match_OO_1 = OO_1,
		@Match_OO_2 = OO_2,
		@Found = 1
	FROM Matches
	WHERE Id = @MatchId

	IF @Found <> 1
	BEGIN
		RAISERROR('Debat s daným id neexistuje!', 16, 1)
		RETURN
	END

	DECLARE @Match_OG_1_Score INT = (SELECT Score FROM Players WHERE Id = @Match_OG_1)
	DECLARE @Match_OG_2_Score INT = (SELECT Score FROM Players WHERE Id = @Match_OG_2)
	DECLARE @Match_OO_1_Score INT = (SELECT Score FROM Players WHERE Id = @Match_OO_1)
	DECLARE @Match_OO_2_Score INT = (SELECT Score FROM Players WHERE Id = @Match_OO_2)
	DECLARE @Match_CG_1_Score INT = (SELECT Score FROM Players WHERE Id = @Match_CG_1)
	DECLARE @Match_CG_2_Score INT = (SELECT Score FROM Players WHERE Id = @Match_CG_2)
	DECLARE @Match_CO_1_Score INT = (SELECT Score FROM Players WHERE Id = @Match_CO_1)
	DECLARE @Match_CO_2_Score INT = (SELECT Score FROM Players WHERE Id = @Match_CO_2)
		
	/* STAGE 2: Výpočet změny skóre */
	
	DECLARE @Match_OG_1_NewScore INT = dbo.GetNewPlayerScore(
		@Match_OG_1_Score, 
		
		@OG_Points, 
		@OG_1_SpeakerPoints, 
		
		@Match_OG_2_Score,
		
		@Match_OO_1_Score,
		@Match_OO_2_Score,
		
		@Match_CG_1_Score,
		@Match_CG_2_Score,
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

	DECLARE @Match_OG_2_NewScore INT = dbo.GetNewPlayerScore(
		@Match_OG_2_Score, 
		
		@OG_Points, 
		@OG_2_SpeakerPoints, 
		
		@Match_OG_1_Score,
		
		@Match_OO_1_Score,
		@Match_OO_2_Score,
		
		@Match_CG_1_Score,
		@Match_CG_2_Score,
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

	DECLARE @Match_OO_1_NewScore INT = dbo.GetNewPlayerScore(
		@Match_OO_1_Score, 
		
		@OO_Points, 
		@OO_1_SpeakerPoints, 
		
		@Match_OO_2_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,
		
		@Match_CG_1_Score,
		@Match_CG_2_Score,
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

		
	DECLARE @Match_OO_2_NewScore INT = dbo.GetNewPlayerScore(
		@Match_OO_2_Score, 
		
		@OO_Points, 
		@OO_2_SpeakerPoints, 
		
		@Match_OO_1_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,
		
		@Match_CG_1_Score,
		@Match_CG_2_Score,
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

	DECLARE @Match_CG_1_NewScore INT = dbo.GetNewPlayerScore(
		@Match_CG_1_Score, 
		
		@CG_Points, 
		@CG_1_SpeakerPoints, 
		
		@Match_CG_2_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,

		@Match_OO_1_Score,
		@Match_OO_2_Score,		
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

	DECLARE @Match_CG_2_NewScore INT = dbo.GetNewPlayerScore(
		@Match_CG_2_Score, 
		
		@CG_Points, 
		@CG_2_SpeakerPoints, 
		
		@Match_CG_1_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,

		@Match_OO_1_Score,
		@Match_OO_2_Score,		
		
		@Match_CO_1_Score,
		@Match_CO_2_Score)

	DECLARE @Match_CO_1_NewScore INT = dbo.GetNewPlayerScore(
		@Match_CO_1_Score, 
		
		@CO_Points, 
		@CO_1_SpeakerPoints, 
		
		@Match_CO_2_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,
		
		@Match_OO_1_Score,
		@Match_OO_2_Score,

		@Match_CG_1_Score,
		@Match_CG_2_Score)

		
	DECLARE @Match_CO_2_NewScore INT = dbo.GetNewPlayerScore(
		@Match_CO_2_Score, 
		
		@CO_Points, 
		@CO_2_SpeakerPoints, 
		
		@Match_CO_1_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,
		
		@Match_OG_1_Score,
		@Match_OG_2_Score,

		@Match_CG_1_Score,
		@Match_CG_2_Score)
		
	/* STAGE 3: Uložení skóre */

	BEGIN TRY
		BEGIN TRANSACTION

		-- Uložení skóre do debaty
		UPDATE Matches
		SET
			OG_Points = @OG_Points,
			OO_Points = @OO_Points,
			CG_Points = @CG_Points,
			CO_Points = @CO_Points,

			OG_1_SpeakerPoints = @OG_1_SpeakerPoints,
			OG_2_SpeakerPoints = @OG_2_SpeakerPoints,
			OO_1_SpeakerPoints = @OO_1_SpeakerPoints,
			OO_2_SpeakerPoints = @OO_2_SpeakerPoints,
			CG_1_SpeakerPoints = @CG_1_SpeakerPoints,
			CG_2_SpeakerPoints = @CG_2_SpeakerPoints,
			CO_1_SpeakerPoints = @CO_1_SpeakerPoints,
			CO_2_SpeakerPoints = @CO_2_SpeakerPoints
		WHERE Id = @MatchId

		-- Nové skóre každému hráči a součet bodů řečníka
		UPDATE Players
		SET
			Score = @Match_OG_1_NewScore,
			Points = Players.Points + @OG_Points,
			SpeakerPoints = Players.SpeakerPoints + @OG_1_SpeakerPoints
		WHERE Id = @Match_OG_1

		UPDATE Players
		SET
			Score = @Match_OG_2_NewScore,
			Points = Players.Points + @OG_Points,
			SpeakerPoints = Players.SpeakerPoints + @OG_2_SpeakerPoints
		WHERE Id = @Match_OG_2

		UPDATE Players
		SET
			Score = @Match_OO_1_NewScore,
			Points = Players.Points + @OO_Points,
			SpeakerPoints = Players.SpeakerPoints + @OO_1_SpeakerPoints
		WHERE Id = @Match_OO_1

		UPDATE Players
		SET
			Score = @Match_OO_2_NewScore,
			Points = Players.Points + @OO_Points,
			SpeakerPoints = Players.SpeakerPoints + @OO_2_SpeakerPoints
		WHERE Id = @Match_OO_2
		
		UPDATE Players
		SET
			Score = @Match_CG_1_NewScore,
			Points = Players.Points + @CG_Points,
			SpeakerPoints = Players.SpeakerPoints + @CG_1_SpeakerPoints
		WHERE Id = @Match_CG_1

		UPDATE Players
		SET
			Score = @Match_CG_2_NewScore,
			Points = Players.Points + @CG_Points,
			SpeakerPoints = Players.SpeakerPoints + @CG_2_SpeakerPoints
		WHERE Id = @Match_CG_2

		UPDATE Players
		SET
			Score = @Match_CO_1_NewScore,
			Points = Players.Points + @CO_Points,
			SpeakerPoints = Players.SpeakerPoints + @CO_1_SpeakerPoints
		WHERE Id = @Match_CO_1

		UPDATE Players
		SET
			Score = @Match_CO_2_NewScore,
			Points = Players.Points + @CO_Points,
			SpeakerPoints = Players.SpeakerPoints + @CO_2_SpeakerPoints
		WHERE Id = @Match_CO_2

		COMMIT TRANSACTION

		RETURN @MatchId
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

END
