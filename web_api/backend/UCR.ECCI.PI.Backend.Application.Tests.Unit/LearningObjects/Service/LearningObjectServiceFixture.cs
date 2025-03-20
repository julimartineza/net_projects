using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.LearningObjects.Service;

[ExcludeFromCodeCoverage]
public class LearningObjectServiceFixture
{
    public LearningObject LearningObject { get; }
    public List<LearningObject> EmptyListLearningObjects { get; }
    public List<LearningObject> LearningObjects { get; }
    public List<LearningObject> LearningObjectsByLearningSpace { get; }
    public string SearchCriteria { get; }
    public string SearchCriteriaWithNoResults { get; }

    public LearningObjectServiceFixture()
    {
        LearningObject = new LearningObject(
            Id.Create("TV"),
            TypeLS.Create("TV"),
            Coordinate.Create(1),
            Coordinate.Create(1),
            Coordinate.Create(2),
            Dimensions.Create(1),
            Dimensions.Create(1),
            Dimensions.Create(1),
            Coordinate.Create(1),
            Coordinate.Create(1),
            Coordinate.Create(1),
            Coordinate.Create(2),
            Name.Create("Lab 1")
        );

        EmptyListLearningObjects = new List<LearningObject>();

        LearningObjects = new List<LearningObject>()
        {
            LearningObject,
            new LearningObject(
                Id.Create("TV"),
                TypeLS.Create("TV"),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Dimensions.Create(1),
                Dimensions.Create(1),
                Dimensions.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Name.Create("Lab 2")
            ),
            new LearningObject(
                Id.Create("TV"),
                TypeLS.Create("TV"),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Dimensions.Create(1),
                Dimensions.Create(1),
                Dimensions.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(1),
                Coordinate.Create(2),
                Name.Create("Lab 1")
            ),
        };

        SearchCriteria = "Lab 1";
        SearchCriteriaWithNoResults = "Lab 3";

        LearningObjectsByLearningSpace = LearningObjects
            .Where(lo => lo.LearningSpaceName == Name.Create(SearchCriteria))
            .ToList();
    }
}
