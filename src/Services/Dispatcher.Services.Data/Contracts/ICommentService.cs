namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task AddCommentAsync<T>(T input);

        Task DeleteCommentAsync(int id);
    }
}
