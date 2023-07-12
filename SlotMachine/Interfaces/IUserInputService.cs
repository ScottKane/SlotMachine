namespace SlotMachine;

public interface IUserInputService
{
    decimal GetValidatedDecimal(string prompt);
}