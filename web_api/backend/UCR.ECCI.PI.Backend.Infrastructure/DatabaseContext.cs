using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using System.Reflection;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using Microsoft.Extensions.Logging;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;

using UCR.ECCI.PI.Backend.Domain.Users.Entities;

using UCR.ECCI.PI.Backend.Domain.Trees.Entities;

namespace UCR.ECCI.PI.Backend.Infrastructure
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Building> Building { get; set; }

        public virtual DbSet<LearningSpace> LearningSpace { get; set; }

        public virtual DbSet<AdministrativeUnit> AdministrativeUnit { get; set; }

        public virtual DbSet<PhysicalUnit> PhysicalUnit { get; set; }

        public virtual DbSet<AdministrativeUnitLocation> AdministrativeUnitLocation { get; set; }

        public virtual DbSet<LearningObject> LearningObjects { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<Tree> Tree { get; set; }


        /// <summary>
        /// Method to get buildings by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<Building> GetBuildingsByName(string name)
        {

            return FromExpression(() => GetBuildingsByName(name));
        }

        /// <summary>
        /// Method to get buildings by name from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<LearningSpace> GetLearningSpacesByBuildingId(string id)
        {
            return FromExpression(() => GetLearningSpacesByBuildingId(id));
        }

        /// <summary>
        /// Method to get learning object by learning space id from the database.
        /// </summary>
        /// <param name="idLS"></param>
        /// <returns></returns>

        public IQueryable<LearningObject> GetLearningObjectByIdLS(string idLS)
        {
            return FromExpression(() => GetLearningObjectByIdLS(idLS));
        }

        /// <summary>
        /// Method to list physical units from the database.
        /// </summary>
        /// <returns></returns>
        public IQueryable<PhysicalUnit> GetListPhysicalUnitNotNull()
        {
            return FromExpression(() => GetListPhysicalUnitNotNull());
        }

        /// <summary>
        /// Method to get all buildings hierarchy from the database.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Building> GetAllBuildingsHierarchy()
        {
            return FromExpression(() => GetAllBuildingsHierarchy());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));

        /// <summary>
        /// Method to map all the functions in the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <exception cref="InvalidOperationException"></exception>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var methodInfo = typeof(DatabaseContext).GetMethod(nameof(GetBuildingsByName));
            if (methodInfo == null)
            {
                throw new InvalidOperationException($"The {nameof(GetBuildingsByName)} method was not found in {nameof(DatabaseContext)}.");
            }

            modelBuilder
                .HasDbFunction(methodInfo)
                .HasName("GetBuildingsByName")
                .HasSchema("dbo");


            var methodInfo2 = typeof(DatabaseContext).GetMethod(nameof(GetListPhysicalUnitNotNull));
            if (methodInfo2 == null)
            {
                throw new InvalidOperationException($"The {nameof(GetListPhysicalUnitNotNull)} method was not found in {nameof(DatabaseContext)}.");
            }

            modelBuilder
                .HasDbFunction(methodInfo2)
                .HasName("GetListPhysicalUnitNotNull")
                .HasSchema("dbo");

            // Mapping configuration

            var methodInfo3 = typeof(DatabaseContext).GetMethod(nameof(GetAllBuildingsHierarchy));
            if (methodInfo3 == null)
            {
                throw new InvalidOperationException($"The {nameof(GetAllBuildingsHierarchy)} method was not found in {nameof(DatabaseContext)}.");
            }

            modelBuilder
                .HasDbFunction(methodInfo3)
                .HasName("GetAllBuildingsHierarchy")
                .HasSchema("dbo");

            var methodInfo4 = typeof(DatabaseContext).GetMethod(nameof(GetLearningSpacesByBuildingId));
            if (methodInfo4 == null)
            {
                throw new InvalidOperationException($"The {nameof(GetLearningSpacesByBuildingId)} method was not found in {nameof(DatabaseContext)}.");
            }

            modelBuilder
                .HasDbFunction(methodInfo4)
                .HasName("GetLearningSpacesByBuildingId");

            var methodInfo5 = typeof(DatabaseContext).GetMethod(nameof(GetLearningObjectByIdLS));
            if (methodInfo5 == null)
            {
                throw new InvalidOperationException($"The {nameof(GetLearningObjectByIdLS)} method was not found in {nameof(DatabaseContext)}.");
            }

            modelBuilder
                .HasDbFunction(methodInfo5)
                .HasName("GetLearningObjectByIdLS")
                .HasSchema("dbo");
        }


        /// <summary>
        /// Method to call stored procedure to edit administrative unit by name
        /// </summary>
        /// <param name="administrativeUnit"></param>
        public void EditAdministrativeUnitByName(AdministrativeUnit administrativeUnit)
        {
             Database.ExecuteSqlRaw("EXEC dbo.EditAdministrativeUnitByName @name, @type, @supervised ",
                                   administrativeUnit.Name.Value, administrativeUnit.AdministrativeUnitType.Value, administrativeUnit.SupervisedBy);
        }

        /// <summary>
        /// Method to call stored procedure to edit building by id
        /// </summary>
        /// <param name="building"></param>
        public void EditBuildingById(Building building)
        {
            Database.ExecuteSqlRaw("EXEC dbo.EditBuildingById @id, @name, " +
                "@acronym, @description, @physicalUnitName, @color, " +
                "@locationX, @locationY, @locationZ, @scaleX, @scaleY, " +
                "@scaleZ, @rotationW, @rotationX, @rotationY, @rotationZ, " +
                "@typeBuilding, @floors", building.Id.Value);
        }

        /// <summary>
        /// Method to call stored procedure to edit physical unit by name
        /// </summary>
        /// <param name="physicalUnit"></param>
        public void EditPhysicalUnitByName(PhysicalUnit physicalUnit)
        {

            Database.ExecuteSqlRaw("EXEC dbo.EditPhysicalUnitByName @name, @physicalUnitType, @locatedIn ",
                                   physicalUnit.Name.Value);
        }

    }
}