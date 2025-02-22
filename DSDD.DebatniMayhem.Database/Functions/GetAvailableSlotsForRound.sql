CREATE FUNCTION [dbo].[GetAvailableSlotsForRound]
(
	@PlayerCount int
)
RETURNS @Result TABLE
(
	Slot VARCHAR(4)
)
AS
BEGIN
	DECLARE @SlotCountPerKind INT = @PlayerCount / 8;

	DECLARE @Counter INT = 0;

	WHILE @Counter < @SlotCountPerKind
	BEGIN
		INSERT INTO @Result (Slot) VALUES ('OG_1'), ('OG_2'), ('OO_1'), ('OO_2'), ('CG_1'), ('CG_2'), ('CO_1'), ('CO_2')

		SET @Counter = @Counter + 1;
	END

	RETURN;
END