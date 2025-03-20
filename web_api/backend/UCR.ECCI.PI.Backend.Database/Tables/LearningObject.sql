CREATE TABLE [dbo].[LearningObject]
(
	[Id] NVARCHAR(17) NOT NULL PRIMARY KEY,
	[TypeLO] NVARCHAR(50) NULL,
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
	[LearningSpaceName] NVARCHAR(40) NOT NULL FOREIGN KEY REFERENCES [dbo].[LearningSpace]([Name])
)
