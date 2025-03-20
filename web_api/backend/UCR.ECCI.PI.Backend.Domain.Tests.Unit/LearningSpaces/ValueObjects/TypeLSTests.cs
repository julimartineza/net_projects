using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.LearningSpaces.ValueObjects;

[ExcludeFromCodeCoverage]
public class TypeLSTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = TypeLS.TryCreate(inputValue, out var typeLS);

        result.Should().BeFalse(because: "The typeLS cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => TypeLS.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty TypeLS value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', TypeLS.MaxLength + 1);

        var result = TypeLS.TryCreate(inputValue, out var typeLS);

        result.Should().BeFalse(because: "The TypeLS exceeds the maximum length of {TypeLS.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', TypeLS.MaxLength + 1);

        Action action = () => TypeLS.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "A TypeLS that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Type";

        var result = TypeLS.TryCreate(inputValue, out var typeLS);

        result.Should().BeTrue(because: "A valid TypeLS should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Type";

        var result = TypeLS.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the TypeLS should be the same as the input value", inputValue);
    }
}
