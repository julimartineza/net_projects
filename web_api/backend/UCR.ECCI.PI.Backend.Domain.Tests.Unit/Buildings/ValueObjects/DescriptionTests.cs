using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Buildings.ValueObjects;

[ExcludeFromCodeCoverage]
public class DescriptionTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = Description.TryCreate(inputValue, out var description);

        result.Should().BeFalse(because: "The description cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => Description.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty Description value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', Description.MaxLength + 1);

        var result = Description.TryCreate(inputValue, out var description);

        result.Should().BeFalse(because: "The description exceeds the maximum length of {Description.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', Description.MaxLength + 1);

        Action action = () => Description.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Description that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Description";

        var result = Description.TryCreate(inputValue, out var description);

        result.Should().BeTrue(because: "A valid description should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Description";

        var result = Description.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the description should be the same as the input value", inputValue);
    }
}