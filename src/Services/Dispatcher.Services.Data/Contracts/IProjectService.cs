namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ProjectModels;

    public interface IProjectService
    {
        Task AddProjectAsync<T>(T input, string id);

        IEnumerable<T> GetAllProjects<T>();

        Task Delete(int id);

        T GetProject<T>(int id);

        Task UpdateAsync(ProjectInputmodel input, int id);
    }
}
