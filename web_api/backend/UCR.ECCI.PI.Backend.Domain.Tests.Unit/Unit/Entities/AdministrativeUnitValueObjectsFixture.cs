using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitValueObjectsFixture
{
    private const string kName = "Vicerrectoria de Investigacion";
    private const string kAdministrativeUnitType = "Vicerrectoria";
    private const string kSupervisor = "Rectoria";
    private const bool kStatus = true;

    public Name Name { get; }
    public AdministrativeUnitType AdministrativeUnitType { get; }
    public Supervisor Supervisor { get; }
    public bool Status { get; }

    public AdministrativeUnitValueObjectsFixture()
    {
        Name = Name.Create(kName);
        AdministrativeUnitType = AdministrativeUnitType.Create(kAdministrativeUnitType);
        Supervisor = Supervisor.Create(kSupervisor);
        Status = kStatus;
    }
}
