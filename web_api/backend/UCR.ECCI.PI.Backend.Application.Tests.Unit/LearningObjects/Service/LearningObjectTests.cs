using FluentAssertions;
using Moq;
using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices.Implementations;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Repositories;

namespace UCR.ECCI.PI.Backend.Application.Tests.Unit.LearningObjects.Service;

[ExcludeFromCodeCoverage]
public class LearningObjectTests : IClassFixture<LearningObjectServiceFixture>
{
    private readonly LearningObjectServiceFixture _fixture;

    public LearningObjectTests(LearningObjectServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ListLearningObjectsAsync_WhenThereIsNoLearningObject_ShouldReturnEmptyList()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.ListLearningObjectsAsync())
            .ReturnsAsync(new List<LearningObject>());
        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.ListLearningObjectsAsync();

        result.Should().BeEmpty(because: "There are no learning objects in the database");
    }

    [Fact]
    public async Task ListLearningObjectsAsync_WhenThereAreLearningObjects_ShouldReturnAListOfLearningObjects()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.ListLearningObjectsAsync())
            .ReturnsAsync(_fixture.LearningObjects);
        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.ListLearningObjectsAsync();

        result.Should().BeEquivalentTo(_fixture.LearningObjects, because: "The service should return the list of learning objects that the repository returns");
    }

    [Fact]
    public async Task SetLearningObjectAsync_WhenGivenValidParameters_ShouldReturn0()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.SetLearningObjectAsync(It.IsAny<LearningObject>()))
            .ReturnsAsync(0);
        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.SetLearningObjectAsync(_fixture.LearningObject);

        result.Should().Be(0, because: "Repository should return the correct creation");
    }

    [Fact]
    public async Task SetLearningObjectAsync_WhenGivenInvalidParameters_ShouldReturn1()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.SetLearningObjectAsync(It.IsAny<LearningObject>()))
            .ReturnsAsync(1);

        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.SetLearningObjectAsync(_fixture.LearningObject);

        result.Should().Be(1, because: "Repository should return 1 due to invalid parameters");
    }

    [Fact]
    public async Task SetLearningObjectAsync_WhenUnexpectedErrorOccurs_ShouldReturn2()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.SetLearningObjectAsync(It.IsAny<LearningObject>()))
            .ReturnsAsync(2);

        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.SetLearningObjectAsync(_fixture.LearningObject);

        result.Should().Be(2, because: "Repository should return 2 due to an unexpected error");
    }

    [Fact]
    public async Task GetLearningObjectsAsync_WhenThereAreLearningObjects_ShouldReturnAListOfLearningObjects()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.GetLearningObjectsAsync(It.IsAny<string>()))
            .ReturnsAsync(_fixture.LearningObjectsByLearningSpace);
        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.GetLearningObjectsAsync(_fixture.SearchCriteria);

        result.Should().BeEquivalentTo(_fixture.LearningObjectsByLearningSpace, because: "The service should return the list of learning objects associated with a learning space id that the repository returns");
    }

    [Fact]
    public async Task GetLearningObjectsAsync_WhenThereIsNoLearningObject_ShouldReturnEmptyList()
    {
        var learningObjectRepositoryMock = new Mock<ILearningObjectRepository>();
        learningObjectRepositoryMock
            .Setup(repository => repository.GetLearningObjectsAsync(It.IsAny<string>()))
            .ReturnsAsync(new List<LearningObject>());
        var learningObjectService = new LearningObjectService(learningObjectRepositoryMock.Object);

        var result = await learningObjectService.GetLearningObjectsAsync(_fixture.SearchCriteriaWithNoResults);

        result.Should().BeEmpty(because: "There are no learning objects in the database");
    }
}