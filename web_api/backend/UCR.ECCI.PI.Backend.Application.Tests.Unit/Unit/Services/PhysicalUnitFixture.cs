using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Unit.Services;

[ExcludeFromCodeCoverage]
public class PhysicalUnitFixture
{
    public PhysicalUnit ValidPhysicalUnitSetParams { get; }
    public PhysicalUnit InvalidPhysicalUnitSetParams { get; }
    public PhysicalUnit ValidPhysicalUnitEditParams { get; }
    public PhysicalUnit InvalidPhysicalUnitEditParams { get; }
    public AdministrativeUnitActiveStatus ValidPhysicalUnitChangeStatusParams { get; }
    public AdministrativeUnitActiveStatus InvalidPhysicalUnitChangeStatusParams { get; }
    public List<PhysicalUnit> PhysicalUnits { get; }
    public string PhysicalUnitName { get; }

    public PhysicalUnitFixture()
    {
        ValidPhysicalUnitSetParams = new PhysicalUnit(
            Name.Create("Finca 4"),
            PhysicalUnitType.Create("Site"),
            LocatedIn.Create("Rodrigo Facio"),
            true
        );

        InvalidPhysicalUnitSetParams = new PhysicalUnit(
            Name.Create("Finca 5"),
            PhysicalUnitType.Create("Site"),
            LocatedIn.Create("Site"),
            true
        );


        ValidPhysicalUnitEditParams = new PhysicalUnit(
            Name.Create("Finca 4"),
            PhysicalUnitType.Create("Site"),
            LocatedIn.Create("Rodrigo Facio"),
            true
        );

        InvalidPhysicalUnitEditParams = new PhysicalUnit(
            Name.Create("Finca 5"),
            PhysicalUnitType.Create("Site"),
            LocatedIn.Create("Site"),
            true
        );

        PhysicalUnits = new List<PhysicalUnit>()
        {
            ValidPhysicalUnitSetParams,
            InvalidPhysicalUnitSetParams,
            ValidPhysicalUnitEditParams,
            InvalidPhysicalUnitEditParams,
        };
        
        ValidPhysicalUnitChangeStatusParams = new AdministrativeUnitActiveStatus(
            Name: "Finca 4",
            status: true
        );

        InvalidPhysicalUnitChangeStatusParams = new AdministrativeUnitActiveStatus(
            Name: "Finca 6",
            status: true
        );

        PhysicalUnitName = "Finca 1";
    }
}
