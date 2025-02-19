CREATE FUNCTION GetActivePlayersPositionHistory() 
RETURNS @Result TABLE 
(
	PlayerId INT NOT NULL, 
	OG_Played BIT NOT NULL,
	OO_PLayed BIT NOT NULL,
	CG_Played BIT NOT NULL, 
	CO_Played BIT NOT NULL,
	UnplayedPositions INT NOT NULL)
AS
BEGIN
	WITH PlayerMatchCounts AS (
		SELECT
			p.Id AS PlayerId,
			SUM(CASE WHEN m.OG_1 = p.Id OR m.OG_2 = p.Id THEN 1 ELSE 0 END) AS OG_Played_Times,
			SUM(CASE WHEN m.OO_1 = p.Id OR m.OO_2 = p.Id THEN 1 ELSE 0 END) AS OO_Played_Times,
			SUM(CASE WHEN m.CG_1 = p.Id OR m.CG_2 = p.Id THEN 1 ELSE 0 END) AS CG_Played_Times,
			SUM(CASE WHEN m.CO_1 = p.Id OR m.CO_2 = p.Id THEN 1 ELSE 0 END) AS CO_Played_Times
		FROM Players p
		LEFT JOIN Matches m ON 
			p.Id IN (m.OG_1, m.OG_2, m.OO_1, m.OO_2, m.CG_1, m.CG_2, m.CO_1, m.CO_2)
		WHERE p.Active = 1
		GROUP BY p.Id
	)

	INSERT INTO @Result
	SELECT 
		PlayerId,
		CAST(OG_Played as bit) as OG_Played,
		CAST(OO_Played as bit) as OO_Played,
		CAST(CG_Played as bit) as CG_Played,
		CAST(CO_Played as bit) as CO_Played,
		4 - (OG_Played + OO_Played + CG_Played + CO_Played) AS UnplayedPositions
	FROM (
		SELECT 
			PlayerId,
			CASE WHEN Adjusted_OG_Played_Times > 0 THEN 1 ELSE 0 END AS OG_Played,
			CASE WHEN Adjusted_OO_Played_Times > 0 THEN 1 ELSE 0 END AS OO_Played,
			CASE WHEN Adjusted_CG_Played_Times > 0 THEN 1 ELSE 0 END AS CG_Played,
			CASE WHEN Adjusted_CO_Played_Times > 0 THEN 1 ELSE 0 END AS CO_Played
		FROM (
			SELECT
				PlayerId,
				OG_Played_Times - MinPlayedTimes AS Adjusted_OG_Played_Times,
				OO_Played_Times - MinPlayedTimes AS Adjusted_OO_Played_Times,
				CG_Played_Times - MinPlayedTimes AS Adjusted_CG_Played_Times,
				CO_Played_Times - MinPlayedTimes AS Adjusted_CO_Played_Times
			FROM (
				SELECT
					PlayerId,
					OG_Played_Times,
					OO_Played_Times,
					CG_Played_Times,
					CO_Played_Times,
					(SELECT MIN(v) 
					 FROM (VALUES (OG_Played_Times), (OO_Played_Times), (CG_Played_Times), (CO_Played_Times)) AS value(v)
					) AS MinPlayedTimes
				FROM PlayerMatchCounts
			) AS AdjustedCounts
		) AS ReducedCounts
	) AS BitAdjustedValues

	RETURN
END