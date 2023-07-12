namespace SlotMachine.Tests;

public class SymbolTranslatorTests
{
    // Arrange
    private readonly SymbolTranslator _translator = new();
    
    [Fact]
    public void Translate_Should_ReturnCorrectChar_ForGivenSymbol()
    {
        // Act
        var apple = _translator.Translate(Symbol.Apple);
        var banana = _translator.Translate(Symbol.Banana);
        var pineapple = _translator.Translate(Symbol.Pineapple);
        var wildcard = _translator.Translate(Symbol.Wildcard);

        // Assert
        Assert.Equal('A', apple);
        Assert.Equal('B', banana);
        Assert.Equal('P', pineapple);
        Assert.Equal('*', wildcard);
    }

    [Fact]
    public void Translate_Should_ThrowArgumentOutOfRangeException_ForInvalidSymbol()
    {
        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _translator.Translate((Symbol)99));
    }
}