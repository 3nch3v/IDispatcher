namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        string GetCreatorId(int dataId);

        Task CreateAsync<T>(T input);

        Task DeleteAsync(int id);
    }
}
