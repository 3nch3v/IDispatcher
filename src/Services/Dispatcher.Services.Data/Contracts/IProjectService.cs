namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IProjectService
    {
        Task AddProjectAsync<T>(T input, string id);
    }
}
