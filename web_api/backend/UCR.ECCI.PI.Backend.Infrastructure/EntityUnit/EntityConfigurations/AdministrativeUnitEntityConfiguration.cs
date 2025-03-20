using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.EntityConfigurations;

/// <summary>
/// Configuration for the administrative unit entity.
/// </summary>
internal class AdministrativeUnitEntityConfiguration : IEntityTypeConfiguration<AdministrativeUnit>
{
    public void Configure(EntityTypeBuilder<AdministrativeUnit> builder)
    {
        builder.HasKey(e => e.Name);

        builder.ToTable("AdministrativeUnit");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => Name.Create(nameString));

        builder.Property(e => e.AdministrativeUnitType)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: administrativeUnitTypeString => AdministrativeUnitType.Create(administrativeUnitTypeString));

        builder.Property(e => e.SupervisedBy)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: supervisedByString => Supervisor.Create(supervisedByString));

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject,
                convertFromProviderExpression: Status => Status);
    }
}
