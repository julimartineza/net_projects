CREATE TABLE [dbo].[Building]
(
    [Id] VARCHAR(17) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(50) NULL,
    [Acronym] VARCHAR(50) NULL, 
    [Description] VARCHAR(100),
    [PhysicalUnitName] VARCHAR(100) NULL,
    [Color] VARCHAR(10),
    [LocationX] DECIMAL(8, 4), 
    [LocationY] DECIMAL(8, 4),
    [LocationZ] DECIMAL(8, 4),
    [ScaleX] DECIMAL(8, 4),
    [ScaleY] DECIMAL(8, 4),
    [ScaleZ] DECIMAL(8, 4),
    [RotationW] DECIMAL(8, 4),
    [RotationX] DECIMAL(8, 4),
    [RotationY] DECIMAL(8, 4),
    [RotationZ] DECIMAL(8, 4),
    [TypeBuilding] VARCHAR(17),
    [Status] BIT NOT NULL,
    [Floors] INT NOT NULL,
    CONSTRAINT FK_PhysicalUnitName FOREIGN KEY ([PhysicalUnitName]) REFERENCES [dbo].[PhysicalUnit]([Name])
);
