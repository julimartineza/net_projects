using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class IdTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = Id.TryCreate(inputValue, out var id);

        result.Should().BeFalse(because: "The id cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => Id.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty Id value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#Id!";

        var result = Id.TryCreate(inputValue, out var id);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => Id.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Id with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', Id.MaxLength + 1);

        var result = Id.TryCreate(inputValue, out var id);

        result.Should().BeFalse(because: "The id exceeds the maximum length of {Id.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', Id.MaxLength + 1);

        Action action = () => Id.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Id that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Id";

        var result = Id.TryCreate(inputValue, out var id);

        result.Should().BeTrue(because: "A valid id should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Id";

        var result = Id.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the Id should be the same as the input value", inputValue);
    }
}
