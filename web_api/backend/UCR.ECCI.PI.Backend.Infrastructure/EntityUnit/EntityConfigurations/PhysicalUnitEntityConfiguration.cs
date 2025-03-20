using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.EntityConfigurations;

/// <summary>
/// Configuration for the physical unit entity.
/// </summary>
internal class PhysicalUnitEntityConfiguration : IEntityTypeConfiguration<PhysicalUnit>
{
    public void Configure(EntityTypeBuilder<PhysicalUnit> builder)
    {
        builder.HasKey(e => e.Name);

        builder.ToTable("PhysicalUnit");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => Name.Create(nameString));

        builder.Property(e => e.PhysicalUnitType)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: physicalUnitTypeString
                    => PhysicalUnitType.Create(physicalUnitTypeString));

        builder.Property(e => e.LocatedIn)
            .IsRequired()
            .HasMaxLength(17).IsUnicode(false)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: locatedInString
                    => LocatedIn.Create(locatedInString));

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject,
                convertFromProviderExpression: Status => Status);
    }
}

