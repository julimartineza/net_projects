using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.Entities;

[ExcludeFromCodeCoverage]
public class BuildingTests : IClassFixture<BuildingValueObjectsFixture>
{
    private readonly BuildingValueObjectsFixture _fixture;

    public BuildingTests(BuildingValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectId()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Id.Value.Should().Be(_fixture.Id.Value, because: "the id given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectName()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Name.Value.Should().Be(_fixture.Name.Value, because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectAcronym()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Acronym.Value.Should().Be(_fixture.Acronym.Value, because: "the acronym given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectDescription()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Description.Value.Should().Be(_fixture.Description.Value, because: "the description given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectPhysicalUnitName()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.PhysicalUnitName.Value.Should().Be(_fixture.PhysicalUnitName.Value, because: "the physical unit name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectColor()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Color.Value.Should().Be(_fixture.Color.Value, because: "the color given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectLocationX()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.LocationX.Value.Should().Be(_fixture.LocationX.Value, because: "the location X given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectLocationY()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.LocationY.Value.Should().Be(_fixture.LocationY.Value, because: "the location Y given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectLocationZ()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.LocationZ.Value.Should().Be(_fixture.LocationZ.Value, because: "the location Z given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleX()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.ScaleX.Value.Should().Be(_fixture.ScaleX.Value, because: "the scale X given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleY()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.ScaleY.Value.Should().Be(_fixture.ScaleY.Value, because: "the scale Y given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectScaleZ()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.ScaleZ.Value.Should().Be(_fixture.ScaleZ.Value, because: "the scale Z given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectRotationW()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.RotationW.Value.Should().Be(_fixture.RotationW.Value, because: "the rotation W given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectRotationX()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.RotationX.Value.Should().Be(_fixture.RotationX.Value, because: "the rotation X given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectRotationY()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.RotationY.Value.Should().Be(_fixture.RotationY.Value, because: "the rotation Y given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectRotationZ()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.RotationZ.Value.Should().Be(_fixture.RotationZ.Value, because: "the rotation Z given to the constructor should match what is returned by the property");
    }
    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectTypeBuilding()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.TypeBuilding.Value.Should().Be(_fixture.TypeBuilding.Value, because: "the type of building given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectStatus()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Status.Should().Be(_fixture.Status, because: "the status given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectFloors()
    {
        var building = new Building(
            _fixture.Id,
            _fixture.Name,
            _fixture.Acronym,
            _fixture.Description,
            _fixture.PhysicalUnitName,
            _fixture.Color,
            _fixture.LocationX,
            _fixture.LocationY,
            _fixture.LocationZ,
            _fixture.ScaleX,
            _fixture.ScaleY,
            _fixture.ScaleZ,
            _fixture.RotationW,
            _fixture.RotationX,
            _fixture.RotationY,
            _fixture.RotationZ,
            _fixture.TypeBuilding,
            _fixture.Status,
            _fixture.Floors);

        building.Floors.Value.Should().Be(_fixture.Floors.Value, because: "the floors given to the constructor should match what is returned by the property");
    }
}
