namespace SlotMachine.Tests;

public class UserInputServiceTests
{
    // Arrange
    private readonly Mock<IConsoleReader> _reader = new();
    private readonly Mock<IConsoleWriter> _writer = new();
    private readonly Mock<IUserInputValidator> _validator = new();
    
    [Fact]
    public void GetValidatedDecimal_Should_ReturnCorrectValue_When_InputIsValidDecimal()
    {
        // Arrange
        _reader.Setup(x => x.ReadLine()).Returns("15.23");
        _validator.Setup(x => x.IsValid(It.IsAny<decimal>())).Returns(true);
        
        var input = new UserInputService(_reader.Object, _writer.Object, _validator.Object);
        
        // Act
        var result = input.GetValidatedDecimal(string.Empty);
        
        // Assert
        Assert.Equal(15.23m, result);
    }
    
    [Fact]
    public void GetValidatedDecimal_Should_PrintErrorAndReturnValidDecimal_When_InputIsNotValidThenValidDecimal()
    {
        // Arrange
        var queue = new Queue<string>();
        queue.Enqueue("not a number");
        queue.Enqueue("1.0");
    
        _reader.Setup(x => x.ReadLine()).Returns(queue.Dequeue);
    
        _validator.Setup(x => x.IsValid(It.IsAny<decimal>())).Returns((decimal d) => d > 0m);
        var input = new UserInputService(_reader.Object, _writer.Object, _validator.Object);
    
        // Act
        var result = input.GetValidatedDecimal(string.Empty);
    
        // Assert
        _writer.Verify(x => x.WriteLine("Invalid input. Please, enter a positive number with up to 2 decimal places."), Times.Once);
        Assert.Equal(1.0m, result);
    }
}