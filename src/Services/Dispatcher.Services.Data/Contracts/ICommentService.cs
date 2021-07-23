namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateAsync<T>(T input);

        Task DeleteAsync(int id);

        string GetCreatorId(int dataId);
    }
}
