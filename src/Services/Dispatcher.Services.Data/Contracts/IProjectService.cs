namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProjectService
    {
        Task AddProjectAsync<T>(T input, string id);

        IEnumerable<T> GetAllProjects<T>();

        Task Delete(int id);
    }
}
