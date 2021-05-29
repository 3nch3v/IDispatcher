namespace Dispatcher.Services.Contracts
{
    public interface IStringValidatorService
    {
        bool IsStringValidDecoded(string input, int requiredStringLength);
    }
}
