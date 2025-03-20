using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityLearningObject.EntityConfigurations;

internal class LearningObjectEntityConfiguration : IEntityTypeConfiguration<LearningObject>
{
    /// <summary>
    /// Method to configure the entity learning object
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<LearningObject> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("LearningObject");

        builder.Property(e => e.Id)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: idString => Id.Create(idString));

        builder.Property(e => e.TypeLO)
            .IsRequired()
            .HasMaxLength(50).IsUnicode(false)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: typeLOString => TypeLS.Create(typeLOString));

        builder.Property(e => e.LocationX)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: locationXValue => Coordinate.Create(locationXValue));

        builder.Property(e => e.LocationY)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: locationYValue => Coordinate.Create(locationYValue));

        builder.Property(e => e.LocationZ)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: locationZValue => Coordinate.Create(locationZValue));

        builder.Property(e => e.ScaleX)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleXValue => Dimensions.Create(scaleXValue));

        builder.Property(e => e.ScaleY)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleYValue => Dimensions.Create(scaleYValue));

        builder.Property(e => e.ScaleZ)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: scaleZValue => Dimensions.Create(scaleZValue));

        builder.Property(e => e.RotationW)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: rotationWValue => Coordinate.Create(rotationWValue));

        builder.Property(e => e.RotationX)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: rotationXValue => Coordinate.Create(rotationXValue));

        builder.Property(e => e.RotationY)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: rotationYValue => Coordinate.Create(rotationYValue));

        builder.Property(e => e.RotationZ)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: rotationZValue => Coordinate.Create(rotationZValue));

        builder.Property(e => e.LearningSpaceName)
            .IsRequired()
            .HasMaxLength(17).IsUnicode(false)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: learningSpaceNameString => Name.Create(learningSpaceNameString));
    }
}
