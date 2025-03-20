CREATE TABLE [dbo].[Person]
(
    [PersonId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [FullName] VARCHAR(100) NULL,
    [Nickname] VARCHAR(50) NULL,
    [Username] VARCHAR(50) NULL,
    [Email] VARCHAR(100) NOT NULL
);