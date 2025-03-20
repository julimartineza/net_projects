using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitLocationValueObjectsFixture
{
    private const string kAdministrativeUnitName = "Escuela de Computación e Informática";
    private const string kBuildingId = "ECCI";

    public Name AdministrativeUnitName { get; }
    public Id BuildingId { get; }

    public AdministrativeUnitLocationValueObjectsFixture()
    {
        AdministrativeUnitName = Name.Create(kAdministrativeUnitName);
        BuildingId = Id.Create(kBuildingId);
    }
}
