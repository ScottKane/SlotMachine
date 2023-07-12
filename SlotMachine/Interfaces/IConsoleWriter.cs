namespace SlotMachine;

public interface IConsoleWriter
{
    void WriteLine();
    void WriteLine(string message);
    void PrintBoard(Board board);
}