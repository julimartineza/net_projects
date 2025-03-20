CREATE TABLE [dbo].[AdministrativeUnit]
(
	[Name] VARCHAR(100) NOT NULL PRIMARY KEY, 
    [AdministrativeUnitType] VARCHAR(25) NULL,
	[SupervisedBy] VARCHAR(100) NULL,
	[Status] BIT NOT NULL
	CONSTRAINT FK_AdministrativeUnit_SupervisedBy_Unit FOREIGN KEY ([SupervisedBy]) REFERENCES [dbo].[AdministrativeUnit]([Name])
)


