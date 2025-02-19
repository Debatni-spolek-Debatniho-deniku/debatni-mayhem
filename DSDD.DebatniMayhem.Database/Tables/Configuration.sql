CREATE TABLE [dbo].[Configuration] (
    [Name]  VARCHAR (32)   NOT NULL,
    [Value] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC)
);

