using System.Text;

namespace SlotMachine;

public sealed class ConsoleWriter : IConsoleWriter
{
    private readonly ISymbolTranslator _translator;

    public ConsoleWriter(ISymbolTranslator translator) => _translator = translator;

    public void WriteLine() => Console.WriteLine();
    public void WriteLine(string message) => Console.WriteLine(message);
    
    public void PrintBoard(Board board)
    {
        var builder = new StringBuilder();
        foreach (var row in board.Rows)
        {
            foreach (var symbol in row)
                builder.Append(_translator.Translate(symbol) + " ");
               
            builder.AppendLine();
        }
        Console.Write(builder.ToString());
    }
}