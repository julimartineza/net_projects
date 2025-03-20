using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.ValueObjects;

[ExcludeFromCodeCoverage]
public class PhysicalUnitTypeTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = PhysicalUnitType.TryCreate(inputValue, out var physicalUnitType);

        result.Should().BeFalse(because: "The physicalUnitType cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => PhysicalUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty PhysicalUnitType value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#PhysicalType!";

        var result = PhysicalUnitType.TryCreate(inputValue, out var physicalUnitType);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => PhysicalUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An PhysicalUnitType with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', PhysicalUnitType.MaxLength + 1);

        var result = PhysicalUnitType.TryCreate(inputValue, out var physicalUnitType);

        result.Should().BeFalse(because: "The PhysicalUnitType exceeds the maximum length of {PhysicalUnitType.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', PhysicalUnitType.MaxLength + 1);

        Action action = () => PhysicalUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An PhysicalUnitType that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Type";

        var result = PhysicalUnitType.TryCreate(inputValue, out var physicalUnitType);

        result.Should().BeTrue(because: "A valid PhysicalUnitType should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Type";

        var result = PhysicalUnitType.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the PhysicalUnitType should be the same as the input value", inputValue);
    }
}
