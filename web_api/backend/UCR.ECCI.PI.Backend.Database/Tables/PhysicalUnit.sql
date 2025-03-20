CREATE TABLE [dbo].[PhysicalUnit]
(
	[Name] VARCHAR(100) NOT NULL PRIMARY KEY,
	[PhysicalUnitType] VARCHAR(25) NULL,
	[LocatedIn] VARCHAR(100) NULL FOREIGN KEY REFERENCES [dbo].[PhysicalUnit]([Name]),
	[Status] BIT NOT NULL
)
