using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitLocationTests : IClassFixture<AdministrativeUnitLocationValueObjectsFixture>
{
    private readonly AdministrativeUnitLocationValueObjectsFixture _fixture;

    public AdministrativeUnitLocationTests(AdministrativeUnitLocationValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectName()
    {
        var administrativeUnit = new AdministrativeUnitLocation(
            _fixture.AdministrativeUnitName,
            _fixture.BuildingId);

        administrativeUnit.AdministrativeUnitName.Value.Should().Be(_fixture.AdministrativeUnitName.Value, 
            because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectBuildingId()
    {
        var administrativeUnit = new AdministrativeUnitLocation(
            _fixture.AdministrativeUnitName,
            _fixture.BuildingId);

        administrativeUnit.BuildingId.Value.Should().Be(_fixture.BuildingId.Value,
            because: "the building id given to the constructor should match what is returned by the property");
    }
}
