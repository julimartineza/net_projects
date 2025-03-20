using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Unit.Services;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitFixture
{
    public AdministrativeUnit ValidAdministrativeUnitSetParams { get; }
    public AdministrativeUnitLocation ValidAdministrativeUnitLocationSetParams { get; }
    public AdministrativeUnit InvalidAdministrativeUnitSetParams { get; }
    public AdministrativeUnitLocation InvalidAdministrativeUnitLocationSetParams { get; }
    public AdministrativeUnit ValidAdministrativeUnitEditParams { get; }
    public AdministrativeUnit InvalidAdministrativeUnitEditParams { get; }
    public AdministrativeUnitActiveStatus ValidAdministrativeUnitChangeStatusParams { get; }
    public AdministrativeUnitActiveStatus InvalidAdministrativeUnitChangeStatusParams { get; }
    public string AdministrativeUnitName { get; }

    public AdministrativeUnitFixture()
    {
        ValidAdministrativeUnitSetParams = new AdministrativeUnit(
            Name.Create("Escuela de Computacion"),
            AdministrativeUnitType.Create("School"),
            Supervisor.Create("Vicerrectoría de Docencia"),
            true
        );

        ValidAdministrativeUnitLocationSetParams = new AdministrativeUnitLocation(
            Name.Create("Escuela de Computacion"),
            Id.Create("ECCI")
        );

        InvalidAdministrativeUnitSetParams = new AdministrativeUnit(
            Name.Create("Escuela de Computacion"),
            AdministrativeUnitType.Create("Site"),
            Supervisor.Create("Site"),
            false
        );

        InvalidAdministrativeUnitLocationSetParams = new AdministrativeUnitLocation(
            Name.Create("Escuela de Computacion"),
            Id.Create("ECCI")
        );

        ValidAdministrativeUnitEditParams = new AdministrativeUnit(
            Name.Create("Escuela de Computacion"),
            AdministrativeUnitType.Create("Site"),
            Supervisor.Create("Vicerrectoría de Docencia"),
            true
        );

        InvalidAdministrativeUnitEditParams = new AdministrativeUnit(
            Name.Create("Escuela de Computacion"),
            AdministrativeUnitType.Create("Site"),
            Supervisor.Create("Site"),
            false
        );

        ValidAdministrativeUnitChangeStatusParams = new AdministrativeUnitActiveStatus(
            "Finca 4",
            true
        );

        InvalidAdministrativeUnitChangeStatusParams = new AdministrativeUnitActiveStatus(
            "Finca 6",
            true
        );

        AdministrativeUnitName = "Escuela de Computacion";
    }

}
