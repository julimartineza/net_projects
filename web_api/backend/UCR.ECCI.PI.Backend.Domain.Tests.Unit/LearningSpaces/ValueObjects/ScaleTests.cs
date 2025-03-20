using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using FluentAssertions;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.LearningSpaces.ValueObjects;

[ExcludeFromCodeCoverage]
public class ScaleTest
{
    [Fact]
    public void TryCreate_WithZeroValue_ReturnsFalse()
    {
        decimal inputValue = 0;

        var result = Scale.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The dimension cannot be zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithZeroValue_ThrowsArgumentException()
    {
        var inputValue = 0;

        Action action = () => Scale.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A zero value Scale should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ReturnsFalse()
    {
        decimal inputValue = -1;

        var result = Scale.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The dimension cannot be less than zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ReturnsFalse()
    {
        var inputValue = Scale.LimitValue + 1;

        var result = Scale.TryCreate(inputValue, out var scale);

        result.Should().BeFalse(because: $"The scale cannot be less than the negative limit value of {Scale.LimitValue}", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ThrowsArgumentException()
    {
        var inputValue = Coordinate.LimitValue + 1;

        Action action = () => Coordinate.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Scale that exceeds the limit value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ThrowsArgumentException()
    {
        var inputValue = -1;

        Action action = () => Scale.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A negative value Scale should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ReturnsFalse()
    {
        var inputValue = 1.12345m;

        var result = Scale.TryCreate(inputValue, out var scale);

        result.Should().BeFalse(because: "The scale cannot have more than four decimal places", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ThrowsArgumentException()
    {
        var inputValue = 1.12345m;

        Action action = () => Scale.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Scale with more than four decimal places should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = 1234.5678m;

        var result = Scale.TryCreate(inputValue, out var scale);

        result.Should().BeTrue(because: "The scale is valid", inputValue);
    }
}
