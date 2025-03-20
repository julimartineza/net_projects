using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Id = UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects.Id;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.EntityConfigurations;

/// <summary>
/// Configuration for the administrative unit location.
/// </summary>
internal class AdministrativeUnitSupervisionEntityLocaion : IEntityTypeConfiguration<AdministrativeUnitLocation>
{
    public void Configure(EntityTypeBuilder<AdministrativeUnitLocation> builder)
    {
        builder.HasKey(e => e.AdministrativeUnitName);

        builder.ToTable("AdministrativeUnitLocation");

        builder.Property(e => e.AdministrativeUnitName)
            .IsRequired()
            .HasColumnName("AdministrativeUnitName")
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => Name.Create(nameString));

        builder.Property(e => e.BuildingId)
            .IsRequired()
            .HasColumnName("BuildingId")
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: BuildingId => Id.Create(BuildingId));
    }
}
