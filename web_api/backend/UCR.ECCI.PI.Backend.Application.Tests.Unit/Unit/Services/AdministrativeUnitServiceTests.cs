using Moq;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Application.UnitServices.Implementations;
using FluentAssertions;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.Unit.Services;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitServiceTests : IClassFixture<AdministrativeUnitFixture>
{
    private readonly AdministrativeUnitFixture _fixture;

    public AdministrativeUnitServiceTests(AdministrativeUnitFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task SetAdministrativeUnitAsync_WhenGivenValidParameters_ShouldReturn0()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetAdministrativeUnitAsync(It.IsAny<AdministrativeUnit>()))
            .ReturnsAsync(0);
        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetAdministrativeUnitAsync(_fixture.ValidAdministrativeUnitSetParams, _fixture.ValidAdministrativeUnitLocationSetParams);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task SetAdministrativeUnitAsync_WhenGivenInvalidParameters_ShouldReturn1()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetAdministrativeUnitAsync(It.IsAny<AdministrativeUnit>()))
            .ReturnsAsync(1);

        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetAdministrativeUnitAsync(_fixture.InvalidAdministrativeUnitSetParams, _fixture.InvalidAdministrativeUnitLocationSetParams);

        result.Should().Be(0, because: "Repository should return 0 due to invalid parameters");
    }

    [Fact]
    public async Task SetAdministrativeUnitAsync_WhenUnexpectedErrorOccurs_ShouldReturn2()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetAdministrativeUnitAsync(It.IsAny<AdministrativeUnit>()))
            .ReturnsAsync(2);

        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.SetAdministrativeUnitAsync(_fixture.ValidAdministrativeUnitSetParams, _fixture.ValidAdministrativeUnitLocationSetParams);

        result.Should().Be(0, because: "Repository should return 0 due to an unexpected error");
    }


    [Fact]
    public async Task EditAdministrativeUnitAsync_WhenGivenValidParameters_ShouldReturn1()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.EditAdministrativeUnitAsync(It.IsAny<AdministrativeUnit>()))
            .ReturnsAsync(1);
        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.EditAdministrativeUnitAsync(_fixture.ValidAdministrativeUnitEditParams);

        result.Should().Be(1, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task EditAdministrativeUnitAsync_WhenGiveInvalidParamers_ShouldReturn0()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.EditAdministrativeUnitAsync(It.IsAny<AdministrativeUnit>()))
            .ReturnsAsync(0);
        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.EditAdministrativeUnitAsync(_fixture.InvalidAdministrativeUnitEditParams);

        result.Should().Be(0, because: "Repository returns an error code because it has invalid arguments");
    }

    [Fact]
    public async Task ChangeAdministrativeUnitStatusAsync_WhenGivenValidParameters_ShouldReturn0()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetAdministrativeUnitStatus(_fixture.ValidAdministrativeUnitChangeStatusParams))
            .ReturnsAsync(0);
        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ChangeAdministrativeUnitStatusAsync(_fixture.InvalidAdministrativeUnitChangeStatusParams);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task ChangeAdministrativeUnitStatusAsync_WhenGiveInvalidParamers_ShouldReturn1()
    {
        var physicalUnitRepositoryMock = new Mock<IAdministrativeUnitRepository>();
        physicalUnitRepositoryMock
            .Setup(repository => repository.SetAdministrativeUnitStatus(_fixture.InvalidAdministrativeUnitChangeStatusParams))
            .ReturnsAsync(1);
        var physicalUnitService = new AdministrativeUnitService(physicalUnitRepositoryMock.Object);

        var result = await physicalUnitService.ChangeAdministrativeUnitStatusAsync(_fixture.InvalidAdministrativeUnitChangeStatusParams);

        result.Should().Be(1, because: "Repository returns an error code because it has invalid arguments");
    }
}
