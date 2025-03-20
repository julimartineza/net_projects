using FluentAssertions;
using Moq;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Application.LearningSpacesServices.Implementations;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.LearningSpaces.Service;

[ExcludeFromCodeCoverage]
public class LearningSpaceTests : IClassFixture<LearningSpacesServiceFixture>
{
    private readonly LearningSpacesServiceFixture _fixture;

    public LearningSpaceTests(LearningSpacesServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ListLearningSpacesAsync_WhenThereIsNoLearningSpace_ShouldReturnEmptyList()
    {
        var learningSpaceRepositoryMock = new Mock<ILearningSpaceRepository>();
        learningSpaceRepositoryMock
            .Setup(repository => repository.ListLearningSpacesAsync(_fixture.SearchCriteria))
            .ReturnsAsync(new List<LearningSpace>());
        var learningSpaceService = new LearningSpaceService(learningSpaceRepositoryMock.Object);

        var result = await learningSpaceService.ListLearningSpacesAsync(_fixture.SearchCriteria);

        result.Should().BeEmpty(because: "There are no learning spaces in the database");
    }

    [Fact]
    public async Task ListLearningSpacesAsync_WhenThereAreLearningSpaces_ShouldReturnAListOfLearningSpaces()
    {
        var learningSpaceRepositoryMock = new Mock<ILearningSpaceRepository>();
        learningSpaceRepositoryMock
            .Setup(repository => repository.ListLearningSpacesAsync(_fixture.SearchCriteria))
            .ReturnsAsync(_fixture.LearningSpacesByBuilding);
        var learningSpaceService = new LearningSpaceService(learningSpaceRepositoryMock.Object);

        var result = await learningSpaceService.ListLearningSpacesAsync(_fixture.SearchCriteria);

        result.Should().BeEquivalentTo(_fixture.LearningSpacesByBuilding, because: "The service should return the list of learning spaces associated with a building id that the repository returns");
    }

    [Fact]
    public async Task SetLearningSpaceAsync_WhenGivenValidParameters_ShouldReturn0()
    {
        var learningSpaceRepositoryMock = new Mock<ILearningSpaceRepository>();
        learningSpaceRepositoryMock
            .Setup(repository => repository.SetLearningSpaceAsync(It.IsAny<LearningSpace>()))
            .ReturnsAsync(0);
        var learningSpaceService = new LearningSpaceService(learningSpaceRepositoryMock.Object);

        var result = await learningSpaceService.SetLearningSpaceAsync(_fixture.LearningSpace);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task SetLearningSpaceAsync_WhenGivenInvalidParameters_ShouldReturn1()
    {
        var learningSpaceRepositoryMock = new Mock<ILearningSpaceRepository>();
        learningSpaceRepositoryMock
            .Setup(repository => repository.SetLearningSpaceAsync(It.IsAny<LearningSpace>()))
            .ReturnsAsync(1);
        var learningSpaceService = new LearningSpaceService(learningSpaceRepositoryMock.Object);

        var result = await learningSpaceService.SetLearningSpaceAsync(_fixture.LearningSpace);

        result.Should().Be(1, because: "Repository should return that creation failed");
    }

    [Fact]
    public async Task SetLearningSpaceAsync_WhenUnexpectedErrorOccurs_ShouldReturn2()
    {
        var learningSpaceRepositoryMock = new Mock<ILearningSpaceRepository>();
        learningSpaceRepositoryMock
            .Setup(repository => repository.SetLearningSpaceAsync(It.IsAny<LearningSpace>()))
            .ReturnsAsync(2);
        var learningSpaceService = new LearningSpaceService(learningSpaceRepositoryMock.Object);

        var result = await learningSpaceService.SetLearningSpaceAsync(_fixture.LearningSpace);

        result.Should().Be(2, because: "Repository should return that creation failed");
    }
}
