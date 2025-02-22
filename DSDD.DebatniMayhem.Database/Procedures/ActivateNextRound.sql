CREATE PROCEDURE [dbo].[ActivateRound]
	@NextRoundId INT = NULL
AS
BEGIN
	DECLARE @OngoingRoundId INT = (SELECT Id FROM Rounds WHERE Ongoing = 1)

	IF @OngoingRoundId IS NULL AND @NextRoundId IS NULL
	BEGIN
		RAISERROR('There is no ongoing round to use as reference to active new round. You must specify ID of the round to active!', 16, 1);
		RETURN
	END

	IF @OngoingRoundId IS NOT NULL AND EXISTS(
		SELECT *
		FROM Matches 
		WHERE RoundId = @OngoingRoundId
		AND (
			OG_Points IS NULL OR
			OO_Points IS NULL OR
			CG_Points IS NULL OR
			CO_Points IS NULL OR
			OG_1_SpeakerPoints IS NULL OR
			OG_2_SpeakerPoints IS NULL OR
			OO_1_SpeakerPoints IS NULL OR
			OO_2_SpeakerPoints IS NULL OR
			CG_1_SpeakerPoints IS NULL OR
			CG_2_SpeakerPoints IS NULL OR
			CO_1_SpeakerPoints IS NULL OR
			CO_2_SpeakerPoints IS NULL
		)
	)
	BEGIN
		RAISERROR('Previously ongoing round has unscored mathces! All matches must be scored before activating next round!', 16, 1);
		RETURN
	END
			
	IF @NextRoundId IS NULL
	BEGIN
		-- Bezprostředně další Round po id v @OngoingRoundId
		SET @NextRoundId = (SELECT TOP(1) Id FROM Rounds WHERE @OngoingRoundId < Id ORDER BY Id ASC)
	END

	IF @NextRoundId IS NULL
	BEGIN
		RAISERROR('There is no next pending round! Either prepare next round first of specify ID of the next round!', 16, 1);
		RETURN
	END

	BEGIN TRY
		BEGIN TRANSACTION

		IF @OngoingRoundId IS NOT NULL
			UPDATE Rounds SET Ongoing = 0 WHERE Id = @OngoingRoundId

		UPDATE Rounds SET Ongoing = 1 WHERE Id = @NextRoundId

		COMMIT TRANSACTION

		RETURN @NextRoundId
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();

		IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
END
