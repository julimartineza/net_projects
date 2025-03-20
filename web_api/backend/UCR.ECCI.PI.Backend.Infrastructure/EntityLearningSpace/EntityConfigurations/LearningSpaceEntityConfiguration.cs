using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infraestructure.EntityBuilding.EntityConfigurations;

/// <summary>
/// Configuration for the learning space entity.
/// </summary>
internal class LearningSpaceEntityConfiguration : IEntityTypeConfiguration<LearningSpace>
{
    public void Configure(EntityTypeBuilder<LearningSpace> builder)
    {
        builder.HasKey(e => e.Name);

        builder.ToTable("LearningSpace");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(17).IsUnicode(false)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => Name.Create(nameString));

        builder.Property(e => e.Description)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: descriptionString => Description.Create(descriptionString));

        builder.Property(e => e.ScaleX)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: latitudeValue => Scale.Create(latitudeValue));

        builder.Property(e => e.ScaleY)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: longitudeValue => Scale.Create(longitudeValue));

        builder.Property(e => e.ScaleZ)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: lengthValue => Scale.Create(lengthValue));

        builder.Property(e => e.TypeLS)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: typeBuildingString => TypeLS.Create(typeBuildingString));

        builder.Property(e => e.Floor)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: floorValue => Floor.Create(floorValue));

        builder.Property(e => e.BuildingId)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: buildingIdValue => BuildingId.Create(buildingIdValue));
    }
}