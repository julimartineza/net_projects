CREATE TABLE [dbo].[User]
(
    [UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,  
    [Username] VARCHAR(50) NULL,                
    [Avatar] VARCHAR(255) NULL,                     
    [IsActive] BIT NULL,    
    [Email] VARCHAR(100) NOT NULL
);