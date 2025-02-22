CREATE FUNCTION [dbo].[GetExpectedSpeakerPoints]
(
	@PlayerScore int
)
RETURNS INT
AS
BEGIN
	RETURN	(
		SELECT TOP(1) SpearPoints
		FROM ScoreToSpearPointsIntervals
		WHERE FromScore <= @PlayerScore
		ORDER BY FromScore DESC
	)
END
