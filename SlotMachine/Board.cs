namespace SlotMachine;

public sealed class Board
{
    private readonly Symbol[][] _symbols;
    public Board(Symbol[][] symbols) => _symbols = symbols;

    public IEnumerable<Symbol[]> Rows => _symbols;
}