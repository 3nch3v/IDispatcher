namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        string GetCreatorId(int dataId);

        Task CreateAsync<T>(T input, string userId);

        Task DeleteAsync(int id);
    }
}
