namespace SlotMachine.Tests;

public class GameTests
{
    // Arrange
    private readonly Mock<IConsoleWriter> _writer = new();
    private readonly Mock<IBoardGenerator> _board = new();
    private readonly Mock<IUserInputService> _input = new();
    
    [Fact]
    public void PlayRound_Should_PrintError_When_StakeIsGreaterThanBalance()
    {
        // Arrange
        _board.Setup(service => service.Generate()).Returns(new Board(new[] { new Symbol[3], new Symbol[3], new Symbol[3], new Symbol[3] }));
        _input.Setup(service => service.GetValidatedDecimal(It.IsAny<string>())).Returns(10m);
        var game = new Game(new GameSettings(), _writer.Object, _board.Object, _input.Object)
            {
                Balance = 1
            };

        // Act
        game.PlayRound();

        // Assert
        _writer.Verify(writer => writer.WriteLine("The stake can't be higher than your balance."));
    }
}