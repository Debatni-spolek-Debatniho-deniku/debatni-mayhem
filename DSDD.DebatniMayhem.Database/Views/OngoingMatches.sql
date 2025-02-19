CREATE VIEW OngoingMatches AS
SELECT 
    m.Id as Id,
	m.RoundId as RoundId,
    m.OG_1 as OG_1_Id,
    p1.Name AS OG_1_Name,
    m.OG_2 as OG_2_Id,
    p2.Name AS OG_2_Name,
    m.OO_1 as OO_1_Id,
    p3.Name AS OO_1_Name,
    m.OO_2 as OO_2_Id,
    p4.Name AS OO_2_Name,
    m.CG_1 AS CG_1_Id,
    p5.Name AS CG_1_Name,
    m.CG_2 AS CG_2_Id,
    p6.Name AS CG_2_Name,
    m.CO_1 as CO_1_Id,
    p7.Name AS CO_1_Name,
    m.CO_2 as CO_2_Id,
    p8.Name AS CO_2_Name
FROM Matches m
JOIN Rounds r ON m.RoundId = r.Id
JOIN Players p1 ON m.OG_1 = p1.Id
JOIN Players p2 ON m.OG_2 = p2.Id
JOIN Players p3 ON m.OO_1 = p3.Id
JOIN Players p4 ON m.OO_2 = p4.Id
JOIN Players p5 ON m.CG_1 = p5.Id
JOIN Players p6 ON m.CG_2 = p6.Id
JOIN Players p7 ON m.CO_1 = p7.Id
JOIN Players p8 ON m.CO_2 = p8.Id
WHERE r.Ongoing = 1;