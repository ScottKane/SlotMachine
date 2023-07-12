namespace SlotMachine;

public sealed class UserInputService : IUserInputService
{
    private readonly IConsoleReader _reader;
    private readonly IConsoleWriter _writer;
    private readonly IUserInputValidator _validator;

    public UserInputService(
        IConsoleReader reader,
        IConsoleWriter writer,
        IUserInputValidator validator)
    {
        _reader = reader;
        _writer = writer;
        _validator = validator;
    }
    
    public decimal GetValidatedDecimal(string prompt)
    {
        while (true)
        {
            _writer.WriteLine(prompt);
            var input = _reader.ReadLine();
            if (decimal.TryParse(input, out var value) && _validator.IsValid(value))
                return value;
            _writer.WriteLine("Invalid input. Please, enter a positive number with up to 2 decimal places.");
        }
    }
}