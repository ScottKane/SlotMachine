namespace SlotMachine;

public sealed class RandomNumberBoardGenerator : IBoardGenerator
{
    private const int Rows = 4;
    private const int Columns = 3;
    private readonly GameSettings _settings;

    public RandomNumberBoardGenerator(GameSettings settings) => _settings = settings;

    public Board Generate()
    {
        var random = new Random();
        var board = new Symbol[Rows][];
            
        for (var i = 0; i < Rows; i++)
        {
            board[i] = new Symbol[Columns];
                
            for (var j = 0; j < Columns; j++)
            {
                var percentage = random.NextDouble();
                board[i][j] = DetermineSymbolByProbability(percentage);
            }
        }
            
        return new Board(board);
    }
    
    private Symbol DetermineSymbolByProbability(double percentage)
    {
        if (percentage < _settings.SymbolProbabilities[Symbol.Apple]) 
            return Symbol.Apple;
        if (percentage < _settings.SymbolProbabilities[Symbol.Banana]) 
            return Symbol.Banana;
        
        return percentage < _settings.SymbolProbabilities[Symbol.Pineapple] ? Symbol.Pineapple : Symbol.Wildcard;
    }
}