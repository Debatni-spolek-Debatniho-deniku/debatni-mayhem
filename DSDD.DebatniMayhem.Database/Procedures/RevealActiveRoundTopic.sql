CREATE PROCEDURE [dbo].[RevealActiveRoundTopic]
AS
BEGIN	
	DECLARE @OngoingRoundId INT = (SELECT Id FROM Rounds WHERE Ongoing = 1)

	IF @OngoingRoundId IS NULL
	BEGIN
		RAISERROR('V danou chvíli neprobíhá žádné kolo!', 16, 1);
		RETURN
	END

	IF EXISTS (SELECT * FROM Rounds WHERE Id = @OngoingRoundId AND InfoSlide IS NOT NULL AND ShowInfoSlide = 0)
	BEGIN
		RAISERROR('Toto kolo obsahuje info slide a je tedy nezbytné nejprve odhalit infoslide!', 16, 1);
		RETURN
	END

	UPDATE Rounds SET ShowTopic = 1 WHERE Id = @OngoingRoundId
END
