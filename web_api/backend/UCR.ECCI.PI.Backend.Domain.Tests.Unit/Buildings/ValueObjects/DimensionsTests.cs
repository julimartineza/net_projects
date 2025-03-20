using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class DimensionsTest
{
    [Fact]
    public void TryCreate_WithZeroValue_ReturnsFalse()
    {
        decimal inputValue = 0;

        var result = Dimensions.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The dimension cannot be zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithZeroValue_ThrowsArgumentException()
    {
        var inputValue = 0;

        Action action = () => Dimensions.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A zero value Dimensions should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ReturnsFalse()
    {
        decimal inputValue = -1;

        var result = Dimensions.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The dimension cannot be less than zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ThrowsArgumentException()
    {
        var inputValue = -1;

        Action action = () => Dimensions.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A negative value Dimensions should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ReturnsFalse()
    {
        var inputValue = 1.12345m;

        var result = Dimensions.TryCreate(inputValue, out var dimensions);

        result.Should().BeFalse(because: "The dimensions cannot have more than four decimal places", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ThrowsArgumentException()
    {
        var inputValue = 1.12345m;

        Action action = () => Dimensions.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Dimensions with more than four decimal places should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = 1234.5678m;

        var result = Dimensions.TryCreate(inputValue, out var dimensions);

        result.Should().BeTrue(because: "The dimensions is valid", inputValue);
    }
}