using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class TypeBuildingTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = TypeBuilding.TryCreate(inputValue, out var typeBuilding);

        result.Should().BeFalse(because: "The typeBuilding cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => TypeBuilding.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty TypeBuilding value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#TypeBuilding!";

        var result = TypeBuilding.TryCreate(inputValue, out var typeBuilding);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => TypeBuilding.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An TypeBuilding with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', TypeBuilding.MaxLength + 1);

        var result = TypeBuilding.TryCreate(inputValue, out var typeBuilding);

        result.Should().BeFalse(because: "The typeBuilding exceeds the maximum length of {TypeBuilding.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', TypeBuilding.MaxLength + 1);

        Action action = () => TypeBuilding.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An TypeBuilding that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Type";

        var result = TypeBuilding.TryCreate(inputValue, out var typeBuilding);

        result.Should().BeTrue(because: "A valid typeBuilding should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Type";

        var result = TypeBuilding.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the typeBuilding should be the same as the input value", inputValue);
    }
}
