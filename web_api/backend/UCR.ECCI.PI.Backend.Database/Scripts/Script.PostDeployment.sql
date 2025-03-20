IF NOT EXISTS (SELECT 1 FROM [dbo].[AdministrativeUnit] WHERE [Name] = 'Rectoria')
BEGIN
    INSERT INTO [dbo].[AdministrativeUnit] ([Name], [AdministrativeUnitType], [Status])
    VALUES ('Rectoria', 'Rectoria', 1);  -- LocatedIn = NULL
END
ELSE
BEGIN
    UPDATE [dbo].[AdministrativeUnit]
    SET [AdministrativeUnitType] = 'Rectoria'
    WHERE [Name] = 'Rectoria';
END

GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[PhysicalUnit] WHERE [Name] = 'UCR')
BEGIN
    INSERT INTO [dbo].[PhysicalUnit] ([Name], [PhysicalUnitType], [LocatedIn], [Status])
    VALUES ('UCR', 'Universidad', NULL, 1);  -- LocatedIn = NULL
END
ELSE
BEGIN
    UPDATE [dbo].[PhysicalUnit]
    SET [PhysicalUnitType] = 'Universidad',
        [LocatedIn] = NULL
    WHERE [Name] = 'UCR';
END

GO
--  Step 2 : Insert physical units
MERGE INTO [dbo].[PhysicalUnit] AS TARGET
USING (VALUES
    ('Rodrigo Facio', 'Campus', 'UCR', 1),
    ('Finca 1', 'Site', 'Rodrigo Facio', 1),
    ('Finca 2', 'Site', 'Rodrigo Facio', 1),
    ('Finca 3', 'Site', 'Rodrigo Facio', 1)
) AS SOURCE ([Name], [PhysicalUnitType], [LocatedIn], [Status])
ON TARGET.[Name] = SOURCE.[Name]
WHEN MATCHED THEN
    UPDATE SET 
        [PhysicalUnitType] = SOURCE.[PhysicalUnitType],
        [LocatedIn] = SOURCE.[LocatedIn]
WHEN NOT MATCHED THEN
    INSERT ([Name], [PhysicalUnitType], [LocatedIn], [Status])
    VALUES (SOURCE.[Name], SOURCE.[PhysicalUnitType], SOURCE.[LocatedIn], SOURCE.[Status]);

GO

-- Step 3 Insert Administrative Units

MERGE INTO [dbo].[AdministrativeUnit] AS TARGET
USING (VALUES
    ('Vicerrectoria de Docencia',  'Vicerrectoría', 'Rectoria', 1),
	('Vicerrectoria de Investigación',  'Vicerrectoría', 'Rectoria', 1),
    ('Facultad de Ingenieria','Facultad', 'Vicerrectoria de Docencia', 1),
    ('Escuela de Ciencias de la Computación e Informática', 'Escuela', 'Vicerrectoria de Docencia', 1),
	('CITIC', 'Centro de Investigación', 'Vicerrectoria de Investigación', 1)
) AS SOURCE ([Name], [AdministrativeUnitType], [SupervisedBy], [Status])
ON TARGET.[Name] = SOURCE.[Name]
WHEN MATCHED THEN
    UPDATE SET 
        [AdministrativeUnitType] = SOURCE.[AdministrativeUnitType]
WHEN NOT MATCHED THEN
    INSERT ([Name], [AdministrativeUnitType], [SupervisedBy], [Status])
    VALUES (SOURCE.[Name], SOURCE.[AdministrativeUnitType], SOURCE.[SupervisedBy], SOURCE.[Status]);
GO

-- Step 4: Insert Buildings
MERGE INTO [dbo].[Building] AS TARGET
USING (VALUES
    ('ECCIANNEX', 'Annex', 'AN', 'Secondary Building of computer school', 'Finca 1', 'Grey', 318.7, 3.25, 162, 13.50985, 5, 36.44219, 0, 0, -23.946, 0, 'Library', 1, 6),
    ('ECCI', 'ECCI', 'EC', 'Secondary Building of computer school',  'Finca 1', 'Grey', 263.3, 3.25, 143.4, 26.06145, 5, 20.85607, 0, 0, -18.138, 0, 'School',  1, 3),
    ('TINOCOLIBRARY', 'Library', 'TL', 'Best library of the university',  'Finca 1', 'Brown', 347.3, 3.25, 375, 20.1429, 5, 49.1846, 0, 0, 9.392, 0, 'School', 1, 2),
    ('LETTERS', 'Building A', 'LA', 'Building dedicated to literature', 'Finca 1', 'Blue', 9.9351, -84.0520, 13.7, 45, 25, 38.5, 55.0, 19.0, 12.3, 7.0, 'School', 0, 3),
    ('ECCIA', 'Principal', 'EP', 'First Building of the computer school', 'Finca 1', 'Orange', 9.9348, -84.0507, 14.9, 55, 35, 42.0, 57.0, 23.5, 15.0, 8.2, 'School', 0, 3),
    ('GEOLOGY', 'Unique Building', 'UG', 'Unique building for geology', 'Finca 1', 'Violet', 296.2, 3.25, 132.5, 26.13709, 5, 19.14519, 0, 0, -21.732, 0, 'School',  1, 2),
    ('PHARMA', 'Pharmacy', 'PH', 'Building of the school of pharmacy', 'Finca 1', 'Brown', 9.9358, -84.0510, 16.0, 60, 35, 46.0, 58.0, 24.0, 16.0, 8.8, 'School',  0, 2),
    ('PHARMAAUD', 'Pharma Auditorium', 'PA', 'Auditorium of the school of pharmacy', 'Finca 1', 'Brown', 9.9358, -84.0510, 15.0, 60, 35, 45.5, 59.5, 21.5, 17.2, 8.6, 'Auditorium', 0, 1),
    ('OLDODONTO', 'Old Odontology', 'OO', 'Old building of the school of dentistry', 'Finca 1', 'Brown', 9.9358, -84.0510, 14.2, 60, 35, 44.0, 57.0, 22.0, 14.5, 7.9, 'School',  0, 1),
    ('NEWODONTO', 'New Odontology', 'NO', 'New building of the school of dentistry',  'Finca 1', 'Brown', 9.9358, -84.0510, 16.5, 60, 35, 48.0, 61.0, 25.5, 18.0, 9.1, 'School',  0, 2),
    ('BIOLOGY', 'Biology', 'BI', 'Building of the school of biology', 'Finca 1', 'Blue', 9.9358, -84.0510, 14.0, 60, 35, 43.5, 55.5, 20.0, 13.8, 7.5, 'School',  0, 2),
    ('MICROBIOLOGY', 'Microbiology', 'MI', 'Building of the school of microbiology', 'Finca 1', 'Green', 9.9358, -84.0510, 15.7, 60, 35, 47.0, 60.0, 23.0, 16.2, 8.4, 'School', 0, 2),
    ('CHEMISTRY', 'Chemistry', 'CH', 'Building of the school of chemistry', 'Finca 1', 'Orange', 9.9358, -84.0510, 13.9, 60, 35, 42.8, 55.2, 21.0, 14.9, 7.8, 'School', 0, 2),
    ('PHYSICSMATH', 'Physics and Math', 'PM', 'Building of the school of physics and mathematics', 'Finca 1', 'Orange', 9.9358, -84.0510, 15.6, 60, 35, 40.0, 50.5, 14.8, 11.1, 12.1, 'School',  0, 4),
    ('STUDENTCAFETERIA', 'Dining hall', 'SD', 'Students dinning hall', 'Finca 1', 'Grey', 386.2, 3.25, 238.9, 37.38466, 5, 43.71969, 0, 0, -15.35, 0, 'School', 0, 1),
    ('COMPUTERCENTER', 'Computer center', 'CoC','Informatic center of the UCR', 'Finca 1', 'Grey', 285.236, 3.25, 175.316, 29.649, 5, 25.528, 0, 0, -21.591, 0, 'School', 1, 3),
    ('ADMINB', 'Administrative B', 'AB', 'Building of administrative offices', 'Finca 1', 'Blue', 9.9358, -84.0510, 14.0, 60, 35, 43.5, 55.5, 20.0, 13.8, 7.5, 'Administrative',  0, 4),
    ('ENGINEERING', 'Engineering', 'IN', 'Building of the engineering faculty', 'Finca 2', 'Blue', 9.9358, -84.0510, 14.0, 60, 35, 43.5, 55.5, 20.0, 13.8, 7.5, 'School',  0, 3)
) AS SOURCE (
    [Id], [Name], [Acronym], [Description], [PhysicalUnitName], [Color], 
    [LocationX], [LocationY], [LocationZ], [ScaleX], [ScaleY], [ScaleZ], 
    [RotationW], [RotationX], [RotationY], [RotationZ], [TypeBuilding], 
    [Status], [Floors]
)
ON TARGET.[Id] = SOURCE.[Id]
WHEN MATCHED THEN
    UPDATE SET
        [Name] = SOURCE.[Name],
        [Acronym] = SOURCE.[Acronym],
        [Description] = SOURCE.[Description],
        [PhysicalUnitName] = SOURCE.[PhysicalUnitName],
        [Color] = SOURCE.[Color],
        [LocationX] = SOURCE.[LocationX],
        [LocationY] = SOURCE.[LocationY],
        [LocationZ] = SOURCE.[LocationZ],
        [ScaleX] = SOURCE.[ScaleX],
        [ScaleY] = SOURCE.[ScaleY],
        [ScaleZ] = SOURCE.[ScaleZ],
        [RotationW] = SOURCE.[RotationW],
        [RotationX] = SOURCE.[RotationX],
        [RotationY] = SOURCE.[RotationY],
        [RotationZ] = SOURCE.[RotationZ],
        [TypeBuilding] = SOURCE.[TypeBuilding],
        [Status] = SOURCE.[Status],
        [Floors] = SOURCE.[Floors]
WHEN NOT MATCHED THEN
    INSERT (
        [Id], [Name], [Acronym], [Description], [PhysicalUnitName], [Color], 
        [LocationX], [LocationY], [LocationZ], [ScaleX], [ScaleY], [ScaleZ], 
        [RotationW], [RotationX], [RotationY], [RotationZ], [TypeBuilding], 
        [Status], [Floors]
    )
    VALUES (
        SOURCE.[Id], SOURCE.[Name], SOURCE.[Acronym], SOURCE.[Description], 
        SOURCE.[PhysicalUnitName], SOURCE.[Color], SOURCE.[LocationX], SOURCE.[LocationY], SOURCE.[LocationZ], 
        SOURCE.[ScaleX], SOURCE.[ScaleY], SOURCE.[ScaleZ], SOURCE.[RotationW], SOURCE.[RotationX], 
        SOURCE.[RotationY], SOURCE.[RotationZ], SOURCE.[TypeBuilding], SOURCE.[Status], SOURCE.[Floors]
    );

GO

MERGE INTO [dbo].[LearningSpace] AS TARGET
USING (VALUES
    ('Lab 4-6',  'PIISBD Lab', 1, 1, 1, 'Laboratory', 4, 'ECCI')
) AS SOURCE (
    [Name],
    [Description],
    [ScaleX],
    [ScaleY],
    [ScaleZ],
    [TypeLS],
    [Floor], 
    [BuildingId]
)
ON TARGET.[Name] = SOURCE.[Name]
WHEN MATCHED THEN
    UPDATE SET 
        [Description] = SOURCE.[Description],
        [ScaleX] = SOURCE.[ScaleX],
        [ScaleY] = SOURCE.[ScaleY],
        [ScaleZ] = SOURCE.[ScaleZ],
        [TypeLS] = SOURCE.[TypeLS],
        [Floor] = SOURCE.[Floor],
        [BuildingId] = SOURCE.[BuildingId]
WHEN NOT MATCHED THEN
    INSERT (
        [Name],
        [Description],
        [ScaleX],
        [ScaleY],
        [ScaleZ],
        [TypeLS],
        [Floor],
        [BuildingId]
    )
    VALUES (
        SOURCE.[Name],
        SOURCE.[Description],
        SOURCE.[ScaleX],
        SOURCE.[ScaleY],
        SOURCE.[ScaleZ],
        SOURCE.[TypeLS],
        SOURCE.[Floor],
        SOURCE.[BuildingId]
    );

GO

    -- Step 5 Insert Administrative Units Locations

MERGE INTO [dbo].[AdministrativeUnitLocation] AS TARGET
USING (VALUES
    ('Vicerrectoria de Docencia', 'ADMINB'),
	('Vicerrectoria de Investigación', 'ADMINB'),
    ('Facultad de Ingenieria', 'ENGINEERING'),
	('CITIC', 'ECCI'),
    ('Escuela de Ciencias de la Computación e Informática', 'ECCI'),
    ('Escuela de Ciencias de la Computación e Informática', 'ECCIANNEX')
) AS SOURCE ([AdministrativeUnitName], [BuildingId])
ON TARGET.[AdministrativeUnitName] = SOURCE.[AdministrativeUnitName] AND
   TARGET.[BuildingId] = SOURCE.[BuildingId]
WHEN MATCHED THEN
    UPDATE SET 
        [AdministrativeUnitName] = SOURCE.[AdministrativeUnitName],
        [BuildingId] = SOURCE.[BuildingId]
WHEN NOT MATCHED THEN
    INSERT ([AdministrativeUnitName], [BuildingId])
    VALUES (SOURCE.[AdministrativeUnitName], SOURCE.[BuildingId]);

GO

-- Step 6 Insert Tree Locations

MERGE INTO [dbo].[Tree] AS TARGET
USING (VALUES
    (0, 345.1, 0.2612484, 156.2, 5),
    (1, 348.8, 0.2612484, 185.5, 4),
    (2, 349.6, 0.2612484, 156.2, 3),
    (4, 349, 0.2612484, 202.5, 5),
    (5, 373.8, 0.2612484, 178.7, 4),
    (6, 384.4, 0.2612484, 161.3, 5),
    (7, 336.9, 0.2612484, 245.1, 6),
    (8, 329, 0.2612484, 263.5, 4),
    (9, 322.4, 0.2612484, 280.4, 5),
    (10, 305.2, 0.2612484, 276.2, 7)
) AS SOURCE ([Id], [LocationX], [LocationY], [LocationZ], [Scale])
ON TARGET.[Id] = SOURCE.[Id]
WHEN MATCHED THEN
    UPDATE SET 
        [LocationX] = SOURCE.[LocationX],
        [LocationY] = SOURCE.[LocationY],
        [LocationZ] = SOURCE.[LocationZ],
        [Scale] = SOURCE.[Scale]
WHEN NOT MATCHED THEN
    INSERT ([Id], [LocationX], [LocationY], [LocationZ], [Scale])
    VALUES (SOURCE.[Id], SOURCE.[LocationX], SOURCE.[LocationY], SOURCE.[LocationZ], SOURCE.[Scale]);

GO
