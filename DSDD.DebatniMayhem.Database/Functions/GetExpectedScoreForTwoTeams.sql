CREATE FUNCTION [dbo].[GetExpectedScoreForTwoTeams]
(
	@ForTeamScore int,
	@AgainstTeamScore int
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @TenToOneOddsScoreDifference INT = (SELECT CONVERT(INT, Value) FROM Configuration WHERE Name = 'TenToOneOdds')
	
	RETURN 1.0 / (1.0 + POWER(10.0, ((CAST(@AgainstTeamScore as FLOAT) - @ForTeamScore) / @TenToOneOddsScoreDifference)));
END
