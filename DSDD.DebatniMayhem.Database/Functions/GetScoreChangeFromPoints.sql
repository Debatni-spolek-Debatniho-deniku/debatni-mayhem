CREATE FUNCTION [dbo].[GetScoreChangeFromPoints]
(
	@ActualPoints int,
	@ForTeamScore int,
	@AgainstTeamScore_1 int,
	@AgainstTeamScore_2 int,
	@AgainstTeamScore_3 int
)
RETURNS INT
AS
BEGIN	
	DECLARE @Expected_AgainstTeam_1 FLOAT = (SELECT dbo.GetExpectedScoreForTwoTeams(@ForTeamScore, @AgainstTeamScore_1));
	DECLARE @Expected_AgainstTeam_2 FLOAT = (SELECT dbo.GetExpectedScoreForTwoTeams(@ForTeamScore, @AgainstTeamScore_2));
	DECLARE @Expected_AgainstTeam_3 FLOAT = (SELECT dbo.GetExpectedScoreForTwoTeams(@ForTeamScore, @AgainstTeamScore_3));

	DECLARE @Expected_Sum FLOAT = @Expected_AgainstTeam_1 + @Expected_AgainstTeam_2 + @Expected_AgainstTeam_3;

	DECLARE @K INT = (SELECT CONVERT(INT, Value) FROM Configuration WHERE Name = 'K')

	-- Body jsou na stupnici 0 až 3, součet očekávání je též O až 3 (každé očekávání je 0 až 1), tzn. aby byla změna max o K musí být třetinové.
	RETURN ROUND((@K / 3) * (@ActualPoints - @Expected_Sum), 0);
END
