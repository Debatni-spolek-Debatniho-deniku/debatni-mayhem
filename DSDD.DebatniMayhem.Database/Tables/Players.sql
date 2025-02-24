CREATE TABLE [dbo].[Players] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [PublicId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Score]         INT              DEFAULT ((1500)) NOT NULL,
    [Points]        INT              DEFAULT ((0)) NOT NULL,
    [SpeakerPoints] INT              DEFAULT ((0)) NOT NULL,
    [Active]        BIT              DEFAULT ((1)) NOT NULL,
    [Placeholder] BIT NOT NULL DEFAULT 0, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Points]>=(0)),
    CHECK ([Score]>=(0))
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Players_PublicId]
    ON [dbo].[Players]([PublicId] ASC);
GO

CREATE TRIGGER TR_PlaceholderZeroValues
    ON Players
    AFTER INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON

		DECLARE @ToZero TABLE (Id INT);
		INSERT INTO @ToZero
		SELECT Id
		FROM inserted
		WHERE Placeholder = 1
		AND (Score <> 0 OR Points <> 0 OR SpeakerPoints <> 0)

		UPDATE Players
		SET
			Score = 0,
			Points = 0,
			SpeakerPoints = 0
		WHERE Id IN (SELECT Id FROM @ToZero)
    END