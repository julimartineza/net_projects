CREATE FUNCTION dbo.GetBuildingsByName (
    @name NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT *
    FROM Building
    WHERE (Name LIKE '%' + @name + '%')
      OR (Description LIKE '%' + @name + '%')
);

GO
CREATE Procedure dbo.EditAdministrativeUnitByName
    @name VARCHAR(100),                     
    @administrativeUnitType VARCHAR(25),    
    @supervisedBy VARCHAR(100) 

AS
BEGIN

 DECLARE @AdministrativeUnitNameChecked VARCHAR(100);
  SET @AdministrativeUnitNameChecked = (SELECT Name 
                                          FROM dbo.AdministrativeUnit 
                                          WHERE Name = @name);
  DECLARE @SupervisedCheck VARCHAR(25);
   SET @SupervisedCheck = (SELECT Name 
                            FROM dbo.AdministrativeUnit 
                            WHERE Name = @supervisedBy);

 IF @AdministrativeUnitNameChecked IS NULL
    BEGIN
        SELECT 'AdministrativeUnit not found' AS Result;
        RETURN;
    END

     IF @supervisedBy IS NULL
    BEGIN
        SELECT 'AdministrativeUnit not found' AS Result;
        RETURN;
    END



    UPDATE  AdministrativeUnit 
    SET 
      AdministrativeUnitType = @administrativeUnitType,  
        SupervisedBy = @supervisedBy                       
    WHERE Name= @name
END

GO

Create Function dbo.GetBuildingById (
	@id VARCHAR(17)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM Building
	WHERE Id = @id
);
GO

CREATE PROCEDURE dbo.EditBuildingById
    @id VARCHAR(17),
	@name VARCHAR(50),
	@acronym VARCHAR(50),
	@description VARCHAR(100),
	@physicalUnitName VARCHAR(100),
	@color VARCHAR(10),
	@locationX DECIMAL(8, 4),
	@locationY DECIMAL(8, 4),
	@locationZ DECIMAL(8, 4),
	@scaleX DECIMAL(8, 4),
	@scaleY DECIMAL(8, 4),
	@scaleZ DECIMAL(8, 4),
	@rotationW DECIMAL(8, 4),
	@rotationX DECIMAL(8, 4),
	@rotationY DECIMAL(8, 4),
	@rotationZ DECIMAL(8, 4),
	@typeBuilding VARCHAR(17),
	@floors INT
AS
BEGIN
	UPDATE Building
	SET 
		Name = @name,
		Acronym = @acronym,
		Description = @description,
		PhysicalUnitName = @physicalUnitName,
		Color = @color,
		LocationX = @locationX,
		LocationY = @locationY,
		LocationZ = @locationZ,
		ScaleX = @scaleX,
		ScaleY = @scaleY,
		ScaleZ = @scaleZ,
		RotationW = @rotationW,
		RotationX = @rotationX,
		RotationY = @rotationY,
		RotationZ = @rotationZ,
		TypeBuilding = @typeBuilding,
		Floors = @floors
	WHERE Id = @id
END
GO

CREATE FUNCTION dbo.GetListPhysicalUnitNotNull ()
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        Name,
        PhysicalUnitType,
        ISNULL(LocatedIn, '----------') AS LocatedIn
    FROM 
        PhysicalUnit
    WHERE 
        Name IS NOT NULL
        AND PhysicalUnitType IS NOT NULL
);
GO

CREATE FUNCTION dbo.GetAllBuildingsHierarchy()
RETURNS TABLE
AS
RETURN
(
    WITH CTE_PhysicalUnit AS (
        SELECT 
            pu.Name,
            pu.LocatedIn,
            CAST(pu.Name AS VARCHAR(MAX)) AS Hierarchy
        FROM 
            PhysicalUnit pu
        UNION ALL
        SELECT 
            pu.Name,
            pu.LocatedIn,
            CAST(cte.Hierarchy + ' -> ' + pu.Name AS VARCHAR(MAX)) AS Hierarchy
        FROM 
            PhysicalUnit pu
        INNER JOIN 
            CTE_PhysicalUnit cte ON pu.LocatedIn = cte.Name
    ),
    CTE_BuildingHierarchy AS (
        SELECT 
            b.Id,
            b.Name,
            b.Acronym,
            b.Description,
            cte.Hierarchy AS PhysicalUnitName,
            b.Color,
            b.LocationX,
            b.LocationY,
            b.LocationZ,
            b.ScaleX,
            b.ScaleY,
            b.ScaleZ,
            b.RotationW,
            b.RotationX,
            b.RotationY,
            b.RotationZ,
            b.TypeBuilding,
            b.Status,
            b.Floors,
            ROW_NUMBER() OVER (PARTITION BY b.Id ORDER BY LEN(cte.Hierarchy) DESC) AS RowNum
        FROM 
            Building b
        LEFT JOIN 
            CTE_PhysicalUnit cte ON b.PhysicalUnitName = cte.Name
    )
    SELECT 
        Id,
        Name,
        Acronym,
        Description,
        PhysicalUnitName,
        Color,
        LocationX,
        LocationY,
        LocationZ,
        ScaleX,
        ScaleY,
        ScaleZ,
        RotationW,
        RotationX,
        RotationY,
        RotationZ,
        TypeBuilding,
        Status,
        Floors
    FROM 
        CTE_BuildingHierarchy
    WHERE 
        RowNum = 1
);
GO

CREATE FUNCTION GetAdministrativeUnitsHierarchyTable
    (@IdBusqueda VARCHAR(17) -- BuildingId parameter
    )
RETURNS TABLE
AS
RETURN
(
    WITH cte AS (
        -- Anchor: Finds all admininistratives units located in the building
        SELECT 
            u.Name AS AdministrativeUnitName,
            u.SupervisedBy,
            CAST(u.Name AS VARCHAR(MAX)) AS Path
        FROM AdministrativeUnitLocation ul
        INNER JOIN AdministrativeUnit u
            ON ul.AdministrativeUnitName = u.Name
        WHERE ul.BuildingId = @IdBusqueda

        UNION ALL

        -- Recursive:  Scale the hierarchy using the SupervisedBy attribute for each unit
        SELECT 
            u.Name AS AdministrativeUnitName,
            u.SupervisedBy,
            CAST(cte.Path + ' -> ' + u.Name AS VARCHAR(MAX)) AS Path
        FROM cte
        INNER JOIN AdministrativeUnit u
            ON cte.SupervisedBy = u.Name
        WHERE u.SupervisedBy IS NOT NULL -- Stops recursion when SupervisedBy is NULL
          AND CHARINDEX(u.Name, cte.Path) = 0 -- Avoids cycles
    )

    -- Final query: Returns AdministrativeUnitName and SupervisedBy
    SELECT DISTINCT AdministrativeUnitName, SupervisedBy
    FROM cte
);
GO


CREATE FUNCTION GetAdministrativeUnitsHierarchyString
    (@IdBusqueda VARCHAR(17) -- BuildingId parameter
    )
RETURNS TABLE
AS
RETURN
(
    WITH cte AS (
        -- Anchor: Finds all admininistratives units located in the building
        SELECT 
            u.Name AS AdministrativeUnitName,
            u.SupervisedBy,
            CAST(u.Name AS VARCHAR(MAX)) AS Path
        FROM AdministrativeUnitLocation ul
        INNER JOIN AdministrativeUnit u
            ON ul.AdministrativeUnitName = u.Name
        WHERE ul.BuildingId = @IdBusqueda

        UNION ALL

        -- Recursive:  Scale the hierarchy using the SupervisedBy attribute for each unit
        SELECT 
            u.Name AS AdministrativeUnitName,
            u.SupervisedBy,
            CAST(u.Name + ' -> ' + cte.Path AS VARCHAR(MAX)) AS Path --Change concatenation for the desired format
        FROM cte
        INNER JOIN AdministrativeUnit u
            ON cte.SupervisedBy = u.Name
    )

    -- Final query: Returns AdministrativeUnitName and SupervisedBy
    SELECT Path
    FROM cte
    WHERE AdministrativeUnitName IN (
        SELECT Name
        FROM AdministrativeUnit
        WHERE SupervisedBy IS NULL
    )
);
GO

-- Function that calls GetAdministrativeUnitsHierarchyString for each building 
CREATE FUNCTION ListBuildingAdministrativeHierarchies() 
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        B.Id, 
        H.Path AS HierarchyString
    FROM 
        Building AS B
    CROSS APPLY 
        GetAdministrativeUnitsHierarchyString(B.Id) AS H
);
GO

CREATE FUNCTION dbo.GetLearningSpacesByBuildingId (
    @buildingId VARCHAR(17)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT *
    FROM LearningSpace
    WHERE BuildingId = @buildingId
);
GO

CREATE FUNCTION dbo.GetLearningObjectByIdLS (
	@IdLS NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM LearningObject
	WHERE LearningSpaceName = @IdLS
);