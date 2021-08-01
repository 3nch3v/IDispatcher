namespace Dispatcher.Services.Contracts
{
    public interface IStringValidatorService
    {
        bool IsStringValid(string input, int requiredStringLength);
    }
}
