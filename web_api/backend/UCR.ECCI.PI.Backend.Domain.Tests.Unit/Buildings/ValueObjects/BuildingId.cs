using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class BuildingIdTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = BuildingId.TryCreate(inputValue, out var buildingId);

        result.Should().BeFalse(because: "The buildingId cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => BuildingId.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty BuildingId value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalbuildingIdCharacters_ReturnsFalse()
    {
        var inputValue = "InvalbuildingId#BuildingId!";

        var result = BuildingId.TryCreate(inputValue, out var buildingId);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalbuildingIdCharacters_ThrowsArgumentException()
    {
        var inputValue = "InvalbuildingId@";

        Action action = () => BuildingId.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An BuildingId with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', BuildingId.MaxLength + 1);

        var result = BuildingId.TryCreate(inputValue, out var buildingId);

        result.Should().BeFalse(because: "The buildingId exceeds the maximum length of {BuildingId.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', BuildingId.MaxLength + 1);

        Action action = () => BuildingId.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An BuildingId that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid BuildingId";

        var result = BuildingId.TryCreate(inputValue, out var buildingId);

        result.Should().BeTrue(because: "A valbuildingId buildingId should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid BuildingId";

        var result = BuildingId.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the BuildingId should be the same as the input value", inputValue);
    }
}

