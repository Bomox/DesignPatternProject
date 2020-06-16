CREATE TABLE [dbo].[Warframes] (
    [ID]     INT        IDENTITY (1, 1) NOT NULL,
    [Name]   NCHAR (50) NOT NULL,
    [Health] INT        NOT NULL,
    [Energy] INT        NOT NULL,
    [Armor]  INT        NOT NULL,
    CONSTRAINT [PK_Warframes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

