namespace SlotMachine;

public sealed class GameSettings
{
    public Dictionary<Symbol, decimal> SymbolCoefficients { get; set; } = new()
    {
        { Symbol.Apple, 0.4m },
        { Symbol.Banana, 0.6m },
        { Symbol.Pineapple, 0.8m },
        { Symbol.Wildcard, 0m }
    };

    public Dictionary<Symbol, double> SymbolProbabilities { get; set; } = new()
    {
        { Symbol.Apple, 0.45 },
        { Symbol.Banana, 0.8 },
        { Symbol.Pineapple, 0.95 },
        { Symbol.Wildcard, 1.0 },
    };
}