using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.ValueObjects;

[ExcludeFromCodeCoverage]
public class AdministrativeUnitTypeTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = AdministrativeUnitType.TryCreate(inputValue, out var administrativeUnitType);

        result.Should().BeFalse(because: "The administrativeUnitType cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => AdministrativeUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty AdministrativeUnitType value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#AdminType!";

        var result = AdministrativeUnitType.TryCreate(inputValue, out var administrativeUnitType);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => AdministrativeUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An AdministrativeUnitType with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', AdministrativeUnitType.MaxLength + 1);

        var result = AdministrativeUnitType.TryCreate(inputValue, out var administrativeUnitType);

        result.Should().BeFalse(because: "The AdministrativeUnitType exceeds the maximum length of {AdministrativeUnitType.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', AdministrativeUnitType.MaxLength + 1);

        Action action = () => AdministrativeUnitType.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An AdministrativeUnitType that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Type";

        var result = AdministrativeUnitType.TryCreate(inputValue, out var administrativeUnitType);

        result.Should().BeTrue(because: "A valid AdministrativeUnitType should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Type";

        var result = AdministrativeUnitType.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the AdministrativeUnitType should be the same as the input value", inputValue);
    }
}
