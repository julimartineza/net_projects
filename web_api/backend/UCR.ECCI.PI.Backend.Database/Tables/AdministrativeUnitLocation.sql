CREATE TABLE [dbo].[AdministrativeUnitLocation]
(
	[AdministrativeUnitName] VARCHAR(100) NOT NULL ,
	[BuildingId] VARCHAR(17) NOT NULL,
	CONSTRAINT PK_LocatedIn PRIMARY KEY ([AdministrativeUnitName], [BuildingId]),
	CONSTRAINT FK_AdministrativeUnit_Location_Unit FOREIGN KEY ([AdministrativeUnitName]) REFERENCES [dbo].[AdministrativeUnit]([Name]),
	CONSTRAINT FK_AdministrativeUnit_Location_Building FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building]([Id])
)
