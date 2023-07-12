namespace SlotMachine.Tests;

public class PositiveTwoDecimalPlacesValidatorTests
{
    // Arrange
    private readonly PositiveTwoDecimalPlacesValidator _validator = new();

    [Theory]
    [InlineData(1.23, true)]
    [InlineData(0.12, true)]
    [InlineData(1.240, true)]
    [InlineData(-1.23, false)]
    [InlineData(1.234, false)]
    public void IsValid_ReturnsExpectedResult(decimal value, bool expectedResult)
    {
        // Act
        var result = _validator.IsValid(value);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}