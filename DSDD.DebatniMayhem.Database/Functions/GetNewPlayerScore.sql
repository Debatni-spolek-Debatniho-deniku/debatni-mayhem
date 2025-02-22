CREATE FUNCTION [dbo].[GetNewPlayerScore]
(
	@ForPlayerScore int,
	@ActualPoints int,
	@ActualSpeakerPoints int,

	@OtherPlayerInTeamScore int,

	@Oponent_1_1_Score int,
	@Oponent_1_2_Score int,

	@Oponent_2_1_Score int,
	@Oponent_2_2_Score int,

	@Oponent_3_1_Score int,
	@Oponent_3_2_Score int
)
RETURNS INT
AS
BEGIN
	DECLARE @TeamScore INT = ROUND((@ForPlayerScore + @OtherPlayerInTeamScore) /2,0);
	DECLARE @OponentTeam_1_Score INT = ROUND((@Oponent_1_1_Score + @Oponent_1_2_Score) /2,0);
	DECLARE @OponentTeam_2_Score INT = ROUND((@Oponent_2_1_Score + @Oponent_2_2_Score) /2,0);
	DECLARE @OponentTeam_3_Score INT = ROUND((@Oponent_3_1_Score + @Oponent_3_2_Score) /2,0);

	DECLARE @ChangeFromPoints INT = (SELECT dbo.GetScoreChangeFromPoints(@ActualPoints, @TeamScore, @OponentTeam_1_Score, @OponentTeam_2_Score, @OponentTeam_3_Score));

	DECLARE @ChangeFromSpeakerPoints INT = (SELECT dbo.GetScoreChangeFromSpeakerPoints(@ActualSpeakerPoints, @ForPlayerScore));

	RETURN @ForPlayerScore + @ChangeFromPoints + @ChangeFromSpeakerPoints;
END
