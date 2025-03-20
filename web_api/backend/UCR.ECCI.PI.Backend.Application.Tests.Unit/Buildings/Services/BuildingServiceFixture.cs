using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Buildings.Services;

[ExcludeFromCodeCoverage]
public class BuildingServiceFixture
{
    public Building Building { get; }
    public List<Building> BuildingsWithCriteria { get; }
    public List<Building> Buildings { get; }
    public string SearchCriteria { get; }
    public string SearchCriteriaWithNoResults { get; }
    public string SearchId { get; }
    public bool Status { get; }

    public BuildingServiceFixture()
    {
        Building = new Building(
            Id.Create("ECCI"),
            Name.Create("Escuela de Computación e Informatica"),
            Name.Create("Compu"),
            Description.Create("Description"),
            Name.Create("Finca 1"),
            Color.Create("Gris"),
            Coordinate.Create(1),
            Coordinate.Create(2),
            Coordinate.Create(3),
            Dimensions.Create(4),
            Dimensions.Create(5),
            Dimensions.Create(6),
            Coordinate.Create(7),
            Coordinate.Create(8),
            Coordinate.Create(9),
            Coordinate.Create(10),
            TypeBuilding.Create("Escuela"),
            true,
            Floors.Create(1)
        );

        Buildings = new List<Building>()
        { Building,
            new Building(
                Id.Create("ECCI"),
                Name.Create("Escuela de Computación e Informatica"),
                Name.Create("Compu"),
                Description.Create("Description"),
                Name.Create("Finca 1"),
                Color.Create("Gris"),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Coordinate.Create(3),
                Dimensions.Create(4),
                Dimensions.Create(5),
                Dimensions.Create(6),
                Coordinate.Create(7),
                Coordinate.Create(8),
                Coordinate.Create(9),
                Coordinate.Create(10),
                TypeBuilding.Create("Escuela"),
                true,
                Floors.Create(1)
            ),
            new Building(
                Id.Create("ECCI"),
                Name.Create("Anexo Escuela de Computación e Informatica"),
                Name.Create("Compu"),
                Description.Create("Description"),
                Name.Create("Finca 1"),
                Color.Create("Gris"),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Coordinate.Create(3),
                Dimensions.Create(4),
                Dimensions.Create(5),
                Dimensions.Create(6),
                Coordinate.Create(7),
                Coordinate.Create(8),
                Coordinate.Create(9),
                Coordinate.Create(10),
                TypeBuilding.Create("Escuela"),
                true,
                Floors.Create(1)
            ),
        };

        SearchCriteria = "Anexo";
        SearchCriteriaWithNoResults = "Anexo 2";
        SearchId = "1";
        Status = true;

        BuildingsWithCriteria = Buildings
            .Where(building => building.Name.Value.Contains(SearchCriteria, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
