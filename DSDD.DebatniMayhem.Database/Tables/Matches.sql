CREATE TABLE [dbo].[Matches] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [RoundId] INT NOT NULL,
    [OG_1]    INT NOT NULL,
    [OG_2]    INT NOT NULL,
    [OO_1]    INT NOT NULL,
    [OO_2]    INT NOT NULL,
    [CG_1]    INT NOT NULL,
    [CG_2]    INT NOT NULL,
    [CO_1]    INT NOT NULL,
    [CO_2]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Matches_CG_1] FOREIGN KEY ([CG_1]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_CG_2] FOREIGN KEY ([CG_2]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_CO_1] FOREIGN KEY ([CO_1]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_CO_2] FOREIGN KEY ([CO_2]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_OG_1] FOREIGN KEY ([OG_1]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_OG_2] FOREIGN KEY ([OG_2]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_OO_1] FOREIGN KEY ([OO_1]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_OO_2] FOREIGN KEY ([OO_2]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_Matches_Round] FOREIGN KEY ([RoundId]) REFERENCES [dbo].[Rounds] ([Id]) ON DELETE CASCADE
);

