CREATE TABLE [dbo].[Rounds] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [InfoSlide] NVARCHAR (MAX) NULL,
    [Topic]    NVARCHAR (MAX) NOT NULL,
    [Ongoing]   BIT            NOT NULL DEFAULT 0,
    [ShowTopic] BIT NOT NULL DEFAULT 0,
    [ShowInfoSlide] BIT NOT NULL DEFAULT 0 CHECK (([InfoSlide] IS NOT NULL AND [ShowInfoSlide] IN (0,1)) OR ([InfoSlide] IS NULL AND [ShowInfoSlide] = 0)), 
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
        RAISERROR('Není možné aktivovat více než 1 kolo současně!', 16, 1);
    END
END;