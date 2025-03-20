using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class LearningObjectTests : IClassFixture<LearningObjectValueObjectsFixture>
{
    private readonly LearningObjectValueObjectsFixture _fixture;

    public LearningObjectTests(LearningObjectValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParameters_ShouldReturnCorrectId()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.Id.Value.Should().Be(_fixture.Id.Value, because: "the id given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParameters_ShouldReturnCorrectTypeLO()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.TypeLO.Value.Should().Be(_fixture.TypeLO.Value, because: "the typeLS given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectLocationX()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.LocationX.Value.Should().Be(_fixture.Coordinate.Value, because: "the locationX given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectLocationY()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.LocationY.Value.Should().Be(_fixture.Coordinate.Value, because: "the locationY given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectLocationZ()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.LocationZ.Value.Should().Be(_fixture.Coordinate.Value, because: "the locationZ given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectScaleX()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.ScaleX.Value.Should().Be(_fixture.Dimensions.Value, because: "the scaleX given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectScaleY()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.ScaleY.Value.Should().Be(_fixture.Dimensions.Value, because: "the scaleY given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectScaleZ()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.ScaleZ.Value.Should().Be(_fixture.Dimensions.Value, because: "the scaleZ given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectRotationw()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.RotationW.Value.Should().Be(_fixture.Coordinate.Value, because: "the rotationX given to the constructor should match what is returned by the property");
    }


    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectRotationX()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.RotationX.Value.Should().Be(_fixture.Coordinate.Value, because: "the rotationX given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectRotationY()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.RotationY.Value.Should().Be(_fixture.Coordinate.Value, because: "the rotationY given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParametes_ShouldReturnCorrectRotationZ()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.RotationZ.Value.Should().Be(_fixture.Coordinate.Value, because: "the rotationZ given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestLearningObjectConstructor_WithValidParameters_ShouldReturnCorrectLearningSpaceName()
    {
        var learningObject = new LearningObject(
            _fixture.Id,
            _fixture.TypeLO,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Dimensions,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Coordinate,
            _fixture.Name
        );

        learningObject.LearningSpaceName.Value.Should().Be(_fixture.Name.Value, because: "the name given to the constructor should match what is returned by the property");
    }
}
