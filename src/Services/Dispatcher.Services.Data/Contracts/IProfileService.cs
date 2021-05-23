namespace Dispatcher.Services.Data.Contracts
{
    public interface IProfileService
    {
        T GetUserById<T>(string id);
    }
}
