namespace SlotMachine;

public sealed class PositiveTwoDecimalPlacesValidator : IUserInputValidator
{
    public bool IsValid(decimal value) => value > 0 && CountDecimalDigits(value) <= 2;
    
    private static int CountDecimalDigits(decimal value)
    {
        var bits = decimal.GetBits(value);
        var exponent = bits[3] >> 16;
        var result = exponent;
        long low = bits[0] | (bits[1] >> 8);
        while (low % 10 == 0)
        {
            result--;
            low /= 10;
        }
        
        return result;
    }
}