namespace SlotMachine;

public sealed class Game
{
    internal decimal Balance;
    
    private readonly IConsoleWriter _writer;
    private readonly IBoardGenerator _board;
    private readonly IUserInputService _input;
    private readonly GameSettings _settings;

    public Game(
        GameSettings settings,
        IConsoleWriter writer,
        IBoardGenerator board,
        IUserInputService input)
    {
        _settings = settings;
        _writer = writer;
        _board = board;
        _input = input;
    }
    
    public void Start()
    {
        Balance = _input.GetValidatedDecimal("Enter your deposit amount:");

        while (Balance > 0)
            PlayRound();

        _writer.WriteLine("Game Over");
    }

    internal void PlayRound()
    {
        var stake = _input.GetValidatedDecimal("What's your stake?");

        if (stake > Balance)
        {
            _writer.WriteLine("The stake can't be higher than your balance.");
            return;
        }

        var board = _board.Generate();

        _writer.WriteLine();
        _writer.PrintBoard(board);
        _writer.WriteLine();

        var win = CalculateWinnings(stake, board);

        Balance += win - stake;

        DisplayRoundResults(win, stake);
    }

    private decimal CalculateWinnings(decimal stake, Board board) =>
        stake * CalculateWinCoefficient(board);

    private void DisplayRoundResults(decimal win, decimal stake)
    {
        if (win > stake)
            _writer.WriteLine($"You won: £{win:F2}");
        else if (win < stake)
            _writer.WriteLine($"You lost: £{-win + stake:F2}");
        else
            _writer.WriteLine("You broke even.");

        _writer.WriteLine($"New balance is: £{Balance:F2}");
        _writer.WriteLine();
    }
    
    private decimal GetSymbolCoefficient(Symbol symbol) =>
        _settings.SymbolCoefficients[symbol];

    private decimal CalculateWinCoefficient(Board board) =>
        board.Rows.Where(CheckRow).Sum(row => row.Sum(GetSymbolCoefficient));

    private static bool CheckRow(Symbol[] row) =>
        row.Where(s => s != Symbol.Wildcard).Distinct().Count() <= 1;
}