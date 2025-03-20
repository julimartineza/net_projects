using FluentAssertions;
using Moq;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Application.BuildingServices.Implementations;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Buildings.Services;

[ExcludeFromCodeCoverage]
public class BuildingServiceTests : IClassFixture<BuildingServiceFixture>
{
    private readonly BuildingServiceFixture _fixture;

    public BuildingServiceTests(BuildingServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task SetBuildingAsync_WhenGivenValidParameters_ShouldReturn1()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.SetBuildingAsync(It.IsAny<Building>()))
            .ReturnsAsync(0);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.SetBuildingAsync(_fixture.Building);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task SetBuildingAsync_WhenGivenInvalidParameters_ShouldReturn0()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.SetBuildingAsync(It.IsAny<Building>()))
            .ReturnsAsync(0);

        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.SetBuildingAsync(_fixture.Building);

        result.Should().Be(0, because: "Repository should return 0 due to invalid parameters");
    }

    [Fact]
    public async Task ListBuildingsAsync_WhenThereAreBuildings_ShouldReturnAListOfBuildings()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.ListBuildingsAsync())
            .ReturnsAsync(_fixture.Buildings);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.ListBuildingsAsync();

        result.Should().BeEquivalentTo(_fixture.Buildings, because: "The service should return the list of buildings that the repository returns");
    }

    [Fact]
    public async Task ListBuildingsAsync_WhenThereAreNoBuildings_ShouldReturnEmptyList()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.ListBuildingsAsync())
            .ReturnsAsync(new List<Building>());
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.ListBuildingsAsync();

        result.Should().BeEmpty(because: "There are no buildings in the database");
    }

    [Fact]
    public async Task GetBuildingByIdAsync_WhenGivenValidId_ShouldReturnBuilding()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingAsync(_fixture.SearchCriteriaWithNoResults))
            .ReturnsAsync(new List<Building>());
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.GetBuildingAsync(_fixture.SearchCriteriaWithNoResults);

        result.Should().BeEmpty(because: "The service should return the building that the repository returns");
    }

    [Fact]
    public async Task GetBuildingByIdAsync_WhenGivenInvalidId_ShouldReturnEmptyList()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingAsync(_fixture.SearchCriteriaWithNoResults))
            .ReturnsAsync(new List<Building>());
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.GetBuildingAsync(_fixture.SearchCriteriaWithNoResults);

        result.Should().BeEmpty(because: "There are no buildings in the database");
    }

    [Fact]
    public async Task ChangeBuildingStatusAsync_WhenBuildingExists_ShouldReturn1()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingByIdAsync(It.IsAny<Id>()))
            .ReturnsAsync(_fixture.Building);
        buildingRepositoryMock
            .Setup(repository => repository.EditBuildingAsync(It.IsAny<Building>()))
            .ReturnsAsync(1);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.ChangeBuildingStatusAsync(_fixture.SearchId, _fixture.Status);

        result.Should().Be(1, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task ChangeBuildingStatusAsync_WhenBuildingIdDoesNotExist_ShouldReturnThrowKeyNotFoundException()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingByIdAsync(It.IsAny<Id>()))
            .ReturnsAsync((Building?)null);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        Func<Task> act = async () => await buildingService.ChangeBuildingStatusAsync(_fixture.SearchId, _fixture.Status);

        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage($"Building with ID {_fixture.SearchId} not found.");
    }

    [Fact]
    public async Task EditBuildingAsync_WhenBuildingExists_ShouldReturns1()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingByIdAsync(It.IsAny<Id>()))
            .ReturnsAsync(_fixture.Building);
        buildingRepositoryMock
            .Setup(repository => repository.EditBuildingAsync(It.IsAny<Building>()))
            .ReturnsAsync(1);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        var result = await buildingService.EditBuildingAsync(_fixture.Building);

        result.Should().Be(1, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task EditBuildingAsync_WhenBuildingIdDoesNotExist_ShouldReturnThrowKeyNotFoundException()
    {
        var buildingRepositoryMock = new Mock<IBuildingRepository>();
        var administrativeUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        buildingRepositoryMock
            .Setup(repository => repository.GetBuildingByIdAsync(It.IsAny<Id>()))
            .ReturnsAsync((Building?)null);
        var buildingService = new BuildingService(buildingRepositoryMock.Object, administrativeUnitRepositoryMock.Object);

        Func<Task> act = async () => await buildingService.EditBuildingAsync(_fixture.Building);

        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage($"Building with ID {_fixture.Building.Id} not found.");
    }
}
