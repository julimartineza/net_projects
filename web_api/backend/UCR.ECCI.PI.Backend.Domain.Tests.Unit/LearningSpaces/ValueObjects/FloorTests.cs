using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using FluentAssertions;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.LearningSpaces.ValueObjects;

[ExcludeFromCodeCoverage]
public class FloorTest
{
    [Fact]
    public void TryCreate_WithZeroValue_ReturnsFalse()
    {
        int inputValue = 0;

        var result = Floor.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The floor cannot be zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithZeroValue_ThrowsArgumentException()
    {
        var inputValue = 0;

        Action action = () => Floor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A zero value Floor should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ReturnsFalse()
    {
        int inputValue = -1;

        var result = Floor.TryCreate(inputValue, out var dimension);

        result.Should().BeFalse(because: "The floor cannot be less than zero", inputValue);
    }

    [Fact]
    public void TryCreate_WithNegativeValue_ThrowsArgumentException()
    {
        var inputValue = -1;

        Action action = () => Floor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A negative value Floor should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ReturnsFalse()
    {
        var inputValue = Floor.LimitValue + 1;

        var result = Floor.TryCreate(inputValue, out var floor);

        result.Should().BeFalse(because: $"The floor cannot exceed the limit value of {Coordinate.LimitValue}", inputValue);
    }

    [Fact]
    public void TryCreate_WithValueGreaterThanLimitValue_ThrowsArgumentException()
    {
        var inputValue = Floor.LimitValue + 1;

        Action action = () => Floor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A Floor that exceeds the positive limit value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = 12;

        var result = Floor.TryCreate(inputValue, out var floor);

        result.Should().BeTrue(because: "The floor is valid", inputValue);
    }
}