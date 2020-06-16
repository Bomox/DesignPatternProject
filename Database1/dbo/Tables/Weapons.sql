CREATE TABLE [dbo].[Weapons] (
    [ID]       INT        IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (50) NOT NULL,
    [Damage]   INT        NOT NULL,
    [Magazine] INT        NOT NULL,
    [Critical] INT        NOT NULL,
    [Status]   INT        NOT NULL,
    CONSTRAINT [PK_Weapons] PRIMARY KEY CLUSTERED ([ID] ASC)
);

