namespace SlotMachine;

public sealed class ConsoleReader : IConsoleReader
{
    public string? ReadLine() => Console.ReadLine();
}