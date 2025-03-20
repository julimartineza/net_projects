using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infraestructure.EntityBuilding.EntityConfigurations;

/// <summary>
/// Configuration for the building entity.
/// </summary>
internal class BuildingEntityConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Building");

        builder.Property(e => e.Id)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: IdString => Id.Create(IdString));

        builder.Property(e => e.Color)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: colorString => Color.Create(colorString));

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(17).IsUnicode(false)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => Name.Create(nameString));

        builder.Property(e => e.Acronym)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: acronymString => Name.Create(acronymString));

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: descriptionString => Description.Create(descriptionString));

        builder.Property(e => e.PhysicalUnitName)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: physicalUnitString => Name.Create(physicalUnitString));

        builder.Property(e => e.LocationX)
           .IsRequired()
           .HasMaxLength(100)
           .HasConversion(
               convertToProviderExpression: valueObject => valueObject.Value,
               convertFromProviderExpression: locationX => Coordinate.Create(locationX));

        builder.Property(e => e.LocationY)
          .IsRequired()
          .HasMaxLength(100)
          .HasConversion(
              convertToProviderExpression: valueObject => valueObject.Value,
              convertFromProviderExpression: locationY => Coordinate.Create(locationY));

        builder.Property(e => e.LocationZ)
          .IsRequired()
          .HasMaxLength(100)
          .HasConversion(
              convertToProviderExpression: valueObject => valueObject.Value,
              convertFromProviderExpression: locationZ => Coordinate.Create(locationZ));

        builder.Property(e => e.ScaleX)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleX => Dimensions.Create(scaleX));


        builder.Property(e => e.ScaleY)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleY => Dimensions.Create(scaleY));


        builder.Property(e => e.ScaleZ)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleZ => Dimensions.Create(scaleZ));

        builder.Property(e => e.RotationW)
          .IsRequired()
          .HasMaxLength(100)
          .HasConversion(
              convertToProviderExpression: valueObject => valueObject.Value,
              convertFromProviderExpression: rotationW => Coordinate.Create(rotationW));

        builder.Property(e => e.RotationX)
          .IsRequired()
          .HasMaxLength(100)
          .HasConversion(
              convertToProviderExpression: valueObject => valueObject.Value,
              convertFromProviderExpression: rotationX => Coordinate.Create(rotationX));

        builder.Property(e => e.RotationY)
         .IsRequired()
         .HasMaxLength(100)
         .HasConversion(
             convertToProviderExpression: valueObject => valueObject.Value,
             convertFromProviderExpression: rotationY => Coordinate.Create(rotationY));

        builder.Property(e => e.RotationZ)
         .IsRequired()
         .HasMaxLength(100)
         .HasConversion(
             convertToProviderExpression: valueObject => valueObject.Value,
             convertFromProviderExpression: rotationZ => Coordinate.Create(rotationZ));

        builder.Property(e => e.TypeBuilding)
        .IsRequired()
        .HasConversion(
            convertToProviderExpression: valueObject => valueObject.Value,
            convertFromProviderExpression: typeBuildingString => TypeBuilding.Create(typeBuildingString));

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject,
                convertFromProviderExpression: Status => Status);

        builder.Property(e => e.Floors)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: floors => Floors.Create(floors));
    }
}
