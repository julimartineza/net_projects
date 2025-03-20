using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class NameTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = Name.TryCreate(inputValue, out var name);

        result.Should().BeFalse(because: "The name cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => Name.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty Name value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#Name!";

        var result = Name.TryCreate(inputValue, out var name);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => Name.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Name with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', Name.MaxLength + 1);

        var result = Name.TryCreate(inputValue, out var name);

        result.Should().BeFalse(because: "The name exceeds the maximum length of {Name.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', Name.MaxLength + 1);

        Action action = () => Name.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Name that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Name";

        var result = Name.TryCreate(inputValue, out var name);

        result.Should().BeTrue(because: "A valid name should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Name";

        var result = Name.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the name should be the same as the input value", inputValue);
    }
}
