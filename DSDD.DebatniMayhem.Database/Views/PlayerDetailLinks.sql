CREATE view PlayerDetailLinks AS
SELECT 
	Name as Name,
	CONCAT((SELECT Value FROM dbo.Configuration WHERE Name = 'PLAYER_DETAIL_ENDPOINT'), '/', PublicId) as DetailLink
FROM dbo.Players