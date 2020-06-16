CREATE TABLE [dbo].[Users] (
    [ID]              INT         IDENTITY (1, 1) NOT NULL,
    [Username]        NCHAR (50)  NOT NULL,
    [PasswordHash]    NCHAR (200) NOT NULL,
    [PasswordSalt]    NCHAR (200) NOT NULL,
    [IsAdministrator] BIT         NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

