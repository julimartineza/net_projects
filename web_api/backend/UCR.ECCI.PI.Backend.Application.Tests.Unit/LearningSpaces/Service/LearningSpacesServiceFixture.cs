using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.LearningSpaces.Service;

[ExcludeFromCodeCoverage]
public class LearningSpacesServiceFixture
{
    public LearningSpace LearningSpace { get; }
    public List<LearningSpace> EmptyListLearningSpaces { get; }
    public List<LearningSpace> LearningSpaces { get; }
    public List<LearningSpace> LearningSpacesByBuilding { get; }

    public string SearchCriteria { get; }

    public LearningSpacesServiceFixture()
    {
        LearningSpace = new LearningSpace(
            Name.Create("Aula 1"),
            Description.Create("Aula de computación"),
            Scale.Create(1),
            Scale.Create(1),
            Scale.Create(1),
            TypeLS.Create("Aula"),
            Floor.Create(1),
            BuildingId.Create("ECCI")
        );

        EmptyListLearningSpaces = new List<LearningSpace>();

        LearningSpaces = new List<LearningSpace>()
        {
            LearningSpace,
            new LearningSpace(
                Name.Create("Aula 2"),
                Description.Create("Aula de computación"),
                Scale.Create(1),
                Scale.Create(1),
                Scale.Create(1),
                TypeLS.Create("Aula"),
                Floor.Create(1),
                BuildingId.Create("ECCI")
            ),
            new LearningSpace(
                Name.Create("Aula 3"),
                Description.Create("Aula de computación"),
                Scale.Create(1),
                Scale.Create(1),
                Scale.Create(1),
                TypeLS.Create("Aula"),
                Floor.Create(1),
                BuildingId.Create("ECCI")
            ),
        };

        SearchCriteria = "ECCI";

        var buildingIdCriteria = BuildingId.Create(SearchCriteria);

        LearningSpacesByBuilding = LearningSpaces
            .Where(ls => ls.BuildingId == buildingIdCriteria)
            .ToList();
    }
}
