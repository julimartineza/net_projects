using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.ValueObjects;

[ExcludeFromCodeCoverage]
public class SupervisorTest
{
    [Fact]
    public void TryCreate_WithEmptyString_ReturnsFalse()
    {
        var inputValue = string.Empty;

        var result = Supervisor.TryCreate(inputValue, out var supervisor);

        result.Should().BeFalse(because: "The supervisor cannot be empty", inputValue);
    }

    [Fact]
    public void TryCreate_WithEmptyString_ThrowsArgumentException()
    {
        var inputValue = string.Empty;

        Action action = () => Supervisor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An empty Supervisor value should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ReturnsFalse()
    {
        var inputValue = "Invalid#Supervisor!";

        var result = Supervisor.TryCreate(inputValue, out var supervisor);

        result.Should().BeFalse(because: "A string with invalid characters is not acceptable", inputValue);
    }

    [Fact]
    public void TryCreate_WithInvalidCharacters_ThrowsArgumentException()
    {
        var inputValue = "Invalid@";

        Action action = () => Supervisor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Supervisor with invalid characters should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ReturnsFalse()
    {
        var inputValue = new string('A', Supervisor.MaxLength + 1);

        var result = Supervisor.TryCreate(inputValue, out var supervisor);

        result.Should().BeFalse(because: "The supervisor exceeds the maximum length of {Supervisor.MaxLenght} characters", inputValue);
    }

    [Fact]
    public void TryCreate_WithLengthGreaterThanMaxLength_ThrowsArgumentException()
    {
        var inputValue = new string('A', Supervisor.MaxLength + 1);

        Action action = () => Supervisor.Create(inputValue);

        FluentActions.Invoking(action).Should().Throw<ArgumentException>(because: "An Supervisor that exceeds the maximum length should throw an ArgumentException", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsTrue()
    {
        var inputValue = "Valid Supervisor";

        var result = Supervisor.TryCreate(inputValue, out var supervisor);

        result.Should().BeTrue(because: "A valid supervisor should be accepted", inputValue);
    }

    [Fact]
    public void TryCreate_WithValidValue_ReturnsCorrectOutputVariable()
    {
        var inputValue = "Valid Supervisor";

        var result = Supervisor.TryCreate(inputValue, out var color);

        color.Value.Should().Be(inputValue, because: "The value of the supervisor should be the same as the input value", inputValue);
    }
}
