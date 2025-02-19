CREATE TABLE [dbo].[Players] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [PublicId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Score]         INT              DEFAULT ((1500)) NOT NULL,
    [Points]        INT              DEFAULT ((0)) NOT NULL,
    [SpeakerPoints] INT              DEFAULT ((0)) NOT NULL,
    [Active]        BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Points]>=(0)),
    CHECK ([Score]>=(0))
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Players_PublicId]
    ON [dbo].[Players]([PublicId] ASC);

