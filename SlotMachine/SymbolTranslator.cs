namespace SlotMachine;

public sealed class SymbolTranslator : ISymbolTranslator
{
    public char Translate(Symbol symbol) =>
        symbol switch
        {
            Symbol.Apple => 'A',
            Symbol.Banana => 'B',
            Symbol.Pineapple => 'P',
            Symbol.Wildcard => '*',
            _ => throw new ArgumentOutOfRangeException(nameof(symbol), "Invalid symbol.")
        };
}