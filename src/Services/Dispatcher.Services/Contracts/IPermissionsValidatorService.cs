namespace Dispatcher.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IPermissionsValidatorService
    {
        Task<bool> HasPermission(string creatorId, string loggedInUserId);
    }
}
