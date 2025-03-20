using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitTests : IClassFixture<AdministrativeUnitValueObjectsFixture>
{
    private readonly AdministrativeUnitValueObjectsFixture _fixture;

    public AdministrativeUnitTests(AdministrativeUnitValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectName()
    {
        var administrativeUnit = new AdministrativeUnit(
            _fixture.Name,
            _fixture.AdministrativeUnitType,
            _fixture.Supervisor,
            _fixture.Status);

        administrativeUnit.Name.Value.Should().Be(_fixture.Name.Value, because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectAdministrativeUnitType()
    {
        var administrativeUnit = new AdministrativeUnit(
            _fixture.Name,
            _fixture.AdministrativeUnitType,
            _fixture.Supervisor,
            _fixture.Status);

        administrativeUnit.AdministrativeUnitType.Value.Should().Be(_fixture.AdministrativeUnitType.Value, because: "the administrative unit type given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectSupervisor()
    {
        var administrativeUnit = new AdministrativeUnit(
            _fixture.Name,
            _fixture.AdministrativeUnitType,
            _fixture.Supervisor,
            _fixture.Status);

        administrativeUnit.SupervisedBy.Value.Should().Be(_fixture.Supervisor.Value, because: "the name given to the constructor should match what is returned by the property");
    }

    [Fact]
    public void TestUnitConstructor_WithValidParameters_ShouldReturnCorrectStatus()
    {
        var administrativeUnit = new AdministrativeUnit(
            _fixture.Name,
            _fixture.AdministrativeUnitType,
            _fixture.Supervisor,
            _fixture.Status);

        administrativeUnit.Status.Should().Be(_fixture.Status, because: "the status given to the constructor should match what is returned by the property");
    }
}