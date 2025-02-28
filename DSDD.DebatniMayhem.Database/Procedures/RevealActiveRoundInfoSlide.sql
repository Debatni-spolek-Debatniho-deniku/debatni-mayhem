CREATE PROCEDURE [dbo].[RevealActiveRoundInfoSlide]
AS
BEGIN	
	DECLARE @OngoingRoundId INT = (SELECT Id FROM Rounds WHERE Ongoing = 1)

	IF @OngoingRoundId IS NULL
	BEGIN
		RAISERROR('V danou chvíli neprobíhá žádné kolo!', 16, 1);
		RETURN
	END

	IF EXISTS (SELECT * FROM Rounds WHERE Id = @OngoingRoundId AND InfoSlide IS NULL)
	BEGIN
		RAISERROR('Toto kolo nemá info slide a je tedy potřeba aktivovat tezi rovnou!', 16, 1);
		RETURN
	END

	UPDATE Rounds SET ShowInfoSlide = 1 WHERE Id = @OngoingRoundId
END
