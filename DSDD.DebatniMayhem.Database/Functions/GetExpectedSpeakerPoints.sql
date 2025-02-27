CREATE FUNCTION [dbo].[GetExpectedSpeakerPoints]
(
	@PlayerScore int
)
RETURNS INT
AS
BEGIN
	RETURN	(
		SELECT TOP(1) SpeakerPoints
		FROM ScoreToSpeakerPointsIntervals
		WHERE FromScore <= @PlayerScore
		ORDER BY FromScore DESC
	)
END
