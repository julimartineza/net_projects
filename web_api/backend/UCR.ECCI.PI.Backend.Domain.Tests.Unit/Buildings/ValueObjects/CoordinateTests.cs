using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class CoordinateTest
{
    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ReturnsFalse()
    {
        var inputValue = Coordinate.LimitValue + 1;

        var result = Coordinate.TryCreate(inputValue, out var coordinate);

        result.Should().BeFalse(because: $"The coordinate cannot exceed the limit value of {Coordinate.LimitValue}", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ThrowsArgumentException()
    {
        var inputValue = Coordinate.LimitValue + 1;

        Action action = () => Coordinate.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Coordinate that exceeds the positive limit value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueLessThanNegativeLimitValue_ReturnsFalse()
    {
        var inputValue = -Coordinate.LimitValue - 1;

        var result = Coordinate.TryCreate(inputValue, out var coordinate);

        result.Should().BeFalse(because: $"The coordinate cannot be less than the negative limit value of {-Coordinate.LimitValue}", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueLessThanLimitValue_ThrowsArgumentException()
    {
        var inputValue = -Coordinate.LimitValue - 1;

        Action action = () => Coordinate.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Coordinate that exceeds the negative limit value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ReturnsFalse()
    {
        var inputValue = 1.12345m;

        var result = Coordinate.TryCreate(inputValue, out var coordinate);

        result.Should().BeFalse(because: "The coordinate cannot have more than four decimal places", inputValue);
    }

    [Fact]
    public void TryCreate_WithMoreThanFourDecimalPlaces_ThrowsArgumentException()
    {
        var inputValue = 1.12345m;

        Action action = () => Coordinate.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Coordinate with more than four decimal places should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = 1234.5678m;

        var result = Coordinate.TryCreate(inputValue, out var coordinate);

        result.Should().BeTrue(because: "The coordinate is valid", inputValue);
    }
}