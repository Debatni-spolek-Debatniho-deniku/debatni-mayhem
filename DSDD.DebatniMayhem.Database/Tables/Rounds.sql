CREATE TABLE [dbo].[Rounds] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [InfoSlide] NVARCHAR (MAX) NULL,
    [Thesis]    NVARCHAR (MAX) NOT NULL,
    [Ongoing]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE TRIGGER TR_EnsureSingleOngoingRound
ON Rounds
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if there are multiple rows with Ongoing = 1
    IF (SELECT COUNT(*) FROM Rounds WHERE Ongoing = 1) > 1
    BEGIN
        THROW 50002, 'Only one row can have Ongoing = 1 at a time.', 1;
        ROLLBACK TRANSACTION;
    END
END;