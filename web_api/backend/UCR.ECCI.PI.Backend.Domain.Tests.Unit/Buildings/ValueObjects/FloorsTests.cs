using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class FloorsTest
{
    [Fact]
    public void TryCreate_WithZeroValue_ReturnsFalse()
    {
        int inputValue = 0;

        var result = Floors.TryCreate(inputValue, out var floors);

        result.Should().BeFalse(because: "The floors cannot be zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithZeroValue_ThrowsArgumentException()
    {
        var inputValue = 0;

        Action action = () => Floors.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A zero value Floosr should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ReturnsFalse()
    {
        int inputValue = -1;

        var result = Floors.TryCreate(inputValue, out var floors);

        result.Should().BeFalse(because: "The floors cannot be less than zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ThrowsArgumentException()
    {
        var inputValue = -1;

        Action action = () => Floors.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A negative value Floors should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ReturnsFalse()
    {
        var inputValue = Floors.LimitValue + 1;

        var result = Floors.TryCreate(inputValue, out var floors);

        result.Should().BeFalse(because: $"The floors cannot exceed the limit value of {Coordinate.LimitValue}", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ThrowsArgumentException()
    {
        var inputValue = Floors.LimitValue + 1;

        Action action = () => Floors.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Floors that exceeds the positive limit value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = 12;

        var result = Floors.TryCreate(inputValue, out var floors);

        result.Should().BeTrue(because: "The floors is valid", inputValue);
    }
}