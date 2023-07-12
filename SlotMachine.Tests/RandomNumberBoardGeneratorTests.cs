namespace SlotMachine.Tests;

public class RandomNumberBoardGeneratorTests
{
    [Fact]
    public void Generate_Should_GenerateExpectedBoard()
    {
        // Arrange
        var settings = new GameSettings();
        var generator = new RandomNumberBoardGenerator(settings);

        // Act
        var board = generator.Generate();

        // Assert
        Assert.Equal(4, board.Rows.Count());
        Assert.True(board.Rows.All(row => row.Length == 3));
    }
}