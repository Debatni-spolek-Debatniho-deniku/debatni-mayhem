CREATE PROCEDURE [dbo].[RevealActiveRoundTopic]
AS
BEGIN	
	DECLARE @OngoingRoundId INT = (SELECT Id FROM Rounds WHERE Ongoing = 1)

	IF @OngoingRoundId IS NULL
	BEGIN
		RAISERROR('V danou chvíli neprobíhá žádné kolo!', 16, 1);
		RETURN
	END

	UPDATE Rounds SET ShowTopic = 1 WHERE Id = @OngoingRoundId
END
