using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class PhysicalUnitTests : IClassFixture<PhysicalUnitValueObjectsFixture>
{
    private readonly PhysicalUnitValueObjectsFixture _fixture;

    public PhysicalUnitTests(PhysicalUnitValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectName()
    {
        // Act
        var physicalUnit = new PhysicalUnit(
            _fixture.Name,
            _fixture.PhysicalUnitType,
            _fixture.LocatedIn,
            _fixture.Status);

        // Assert
        physicalUnit.Name.Value.Should().Be(_fixture.Name.Value, because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectPhysicalUnitType()
    {
        // Act
        var physicalUnit = new PhysicalUnit(
            _fixture.Name,
            _fixture.PhysicalUnitType,
            _fixture.LocatedIn,
            _fixture.Status);

        // Assert
        physicalUnit.PhysicalUnitType.Value.Should().Be(_fixture.PhysicalUnitType.Value, because: "the physical unit type given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectLocatedIn()
    {
        // Act
        var physicalUnit = new PhysicalUnit(
            _fixture.Name,
            _fixture.PhysicalUnitType,
            _fixture.LocatedIn,
            _fixture.Status);

        // Assert
        physicalUnit.LocatedIn.Value.Should().Be(_fixture.LocatedIn.Value, because: "the located in given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectStatus()
    {
        // Act
        var physicalUnit = new PhysicalUnit(
            _fixture.Name,
            _fixture.PhysicalUnitType,
            _fixture.LocatedIn,
            _fixture.Status);

        // Assert
        physicalUnit.Status.Should().Be(_fixture.Status, because: "the status given to the constructor should match what is returned by the property");
    }
}
