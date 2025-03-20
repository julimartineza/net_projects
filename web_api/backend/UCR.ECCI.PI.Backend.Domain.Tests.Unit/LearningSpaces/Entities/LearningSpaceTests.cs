using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.LearningSpaces.Entities;

[ExcludeFromCodeCoverage]
public class LearningSpaceTests : IClassFixture<LearningSpaceValueObjectsFixture>
{
    private readonly LearningSpaceValueObjectsFixture _fixture;

    public LearningSpaceTests(LearningSpaceValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectName()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.Name.Value.Should().Be(_fixture.Name.Value, because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectDescription()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.Description.Value.Should().Be(_fixture.Description.Value, because: "the description given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleX()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.ScaleX.Value.Should().Be(_fixture.ScaleX.Value, because: "the scale x given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleY()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.ScaleY.Value.Should().Be(_fixture.ScaleY.Value, because: "the scale y given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleZ()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.ScaleZ.Value.Should().Be(_fixture.ScaleZ.Value, because: "the scale z given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectTypeLS()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.TypeLS.Value.Should().Be(_fixture.TypeLS.Value, because: "the type of learning space given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectFloor()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.Floor.Value.Should().Be(_fixture.Floor.Value, because: "the floor given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectBuildingId()
    {
        var learningSpace = new LearningSpace(
            _fixture.Name,
            _fixture.Description,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.TypeLS,
            _fixture.Floor,
            _fixture.BuildingId);

        learningSpace.BuildingId.Value.Should().Be(_fixture.BuildingId.Value, because: "the building ID given to the constructor should match what is returned by the property");
    }
}