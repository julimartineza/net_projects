Create Table [dbo].[LearningSpace]
(
	[Name] nvarchar(40) not null primary key,
	[Description] nvarchar(100) not null,
	[ScaleX] decimal(8,4) not null,
	[ScaleY] decimal(8,4) not null,
	[ScaleZ] decimal(8,4) not null,
	[TypeLS] nvarchar(50) not null,
	[Floor] int not null,
	[BuildingId] VARCHAR(17) not null FOREIGN KEY REFERENCES [dbo].[Building]([Id])
);