using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class ColorTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = Color.TryCreate(inputValue, out var color);

        result.Should().BeFalse(because: "The color cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => Color.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty Color value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#Color!";

        var result = Color.TryCreate(inputValue, out var color);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => Color.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Color with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', Color.MaxLength + 1);

        var result = Color.TryCreate(inputValue, out var color);

        result.Should().BeFalse(because: "The color exceeds the maximum length of {Color.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', Color.MaxLength + 1);

        Action action = () => Color.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Color that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Color";

        var result = Color.TryCreate(inputValue, out var color);

        result.Should().BeTrue(because: "A valid color should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Color";

        var result = Color.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the color should be the same as the input value", inputValue);
    }
}
