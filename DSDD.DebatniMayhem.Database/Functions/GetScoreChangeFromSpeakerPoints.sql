CREATE FUNCTION [dbo].[GetScoreChangeFromSpeakerPoints]
(
	@ActualSpeakerPoints int,
	@PlayerScore int
)
RETURNS INT
AS
BEGIN
	DECLARE @ExpectedSpeakerPoints INT = (SELECT dbo.GetExpectedSpeakerPoints(@PlayerScore));
	
	DECLARE @K INT = (SELECT CONVERT(INT, Value) FROM Configuration WHERE Name = 'K')

	RETURN ROUND(@K * (@ActualSpeakerPoints - @ExpectedSpeakerPoints) / 30, 0);
END
