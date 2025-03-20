using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.ValueObjects;

[ExcludeFromCodeCoverage]
public class LocatedInTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = LocatedIn.TryCreate(inputValue, out var locatedIn);

        result.Should().BeFalse(because: "The locatedIn cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => LocatedIn.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty LocatedIn value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#PhysicalType!";

        var result = LocatedIn.TryCreate(inputValue, out var locatedIn);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => LocatedIn.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An LocatedIn with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', LocatedIn.MaxLength + 1);

        var result = LocatedIn.TryCreate(inputValue, out var locatedIn);

        result.Should().BeFalse(because: "The LocatedIn exceeds the maximum length of {LocatedIn.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', LocatedIn.MaxLength + 1);

        Action action = () => LocatedIn.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An LocatedIn that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Type";

        var result = LocatedIn.TryCreate(inputValue, out var locatedIn);

        result.Should().BeTrue(because: "A valid LocatedIn should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Type";

        var result = LocatedIn.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the LocatedIn should be the same as the input value", inputValue);
    }
}
