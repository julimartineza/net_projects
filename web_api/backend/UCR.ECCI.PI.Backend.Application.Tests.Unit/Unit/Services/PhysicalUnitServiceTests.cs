using Moq;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Application.UnitServices.Implementations;
using FluentAssertions;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Unit.Services;

[ExcludeFromCodeCoverage]
public class PhysicalUnitServiceTests : IClassFixture<PhysicalUnitFixture>
{
    private readonly PhysicalUnitFixture _fixture;

    public PhysicalUnitServiceTests(PhysicalUnitFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ListPhysicalUnitAsync_WhenThereIsNoPysicalUnit_ShouldReturnEmptyList()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.ListPhysicalUnitAsync())
            .ReturnsAsync(new List<PhysicalUnit>());
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ListPhysicalUnitAsync();

        result.Should().BeEmpty(because: "There are no physical units in the database");
    }

    [Fact]
    public async Task ListPhysicalUnitAsync_WhenThereArePhysicalUnits_ShouldReturnAListOfPhysicalUnits()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.ListPhysicalUnitAsync())
            .ReturnsAsync(_fixture.PhysicalUnits);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ListPhysicalUnitAsync();

        result.Should().BeEquivalentTo(_fixture.PhysicalUnits, because: "The service should return the same list of physical units that the repository returns");
    }

    [Fact]
    public async Task SetPhysicalUnitAsync_WhenGivenValidParameters_ShouldReturn0()
    { 
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetPhysicalUnitAsync(It.IsAny<PhysicalUnit>()))
            .ReturnsAsync(0);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetPhysicalUnitAsync(_fixture.ValidPhysicalUnitSetParams);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task SetPhysicalUnitAsync_WhenGiveInvalidParamers_ShouldReturn1()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetPhysicalUnitAsync(It.IsAny<PhysicalUnit>()))
            .ReturnsAsync(1);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetPhysicalUnitAsync(_fixture.InvalidPhysicalUnitSetParams);

        result.Should().Be(1, because: "Repository returns an error code because it has invalid arguments");
    }

    [Fact]
    public async Task SetPhysicalUnitAsync_WhenUnexpectedErrorOccurs_ShouldReturn2()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetPhysicalUnitAsync(It.IsAny<PhysicalUnit>()))
            .ReturnsAsync(2); 

        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetPhysicalUnitAsync(_fixture.InvalidPhysicalUnitSetParams);

        result.Should().Be(2, because: "An unexpected error occurred and the service should return 2.");
    }


    [Fact]
    public async Task EditPhysicalUnitAsync_WhenGivenValidParameters_ShouldReturn0()
    { 
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.EditPhysicalUnitAsync(It.IsAny<PhysicalUnit>()))
            .ReturnsAsync(0);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.EditPhysicalUnitAsync(_fixture.ValidPhysicalUnitEditParams);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task EditPhysicalUnitAsync_WhenGiveInvalidParamers_ShouldReturn0()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.EditPhysicalUnitAsync(It.IsAny<PhysicalUnit>()))
            .ReturnsAsync(0);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.EditPhysicalUnitAsync(_fixture.InvalidPhysicalUnitEditParams);

        result.Should().Be(0, because: "Repository returns an error code because it has invalid arguments");
    }

    [Fact]
    public async Task ChangePhysicalUnitStatusAsync_WhenGivenValidParameters_ShouldReturn0()
    { 
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetPhysicalUnitStatus(_fixture.ValidPhysicalUnitChangeStatusParams))
            .ReturnsAsync(0);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ChangePhysicalUnitStatusAsync(_fixture.InvalidPhysicalUnitChangeStatusParams);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task ChangePhysicalUnitStatusAsync_WhenGiveInvalidParamers_ShouldReturn0()
    {
        var physicalUnitRepositoryMock = new Mock<IPhysicalUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetPhysicalUnitStatus(_fixture.InvalidPhysicalUnitChangeStatusParams))
            .ReturnsAsync(0);
        var physicalUnitService = new PhysicalUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ChangePhysicalUnitStatusAsync(_fixture.InvalidPhysicalUnitChangeStatusParams);

        result.Should().Be(0, because: "Repository returns an error code because it has invalid arguments");
    }
}
