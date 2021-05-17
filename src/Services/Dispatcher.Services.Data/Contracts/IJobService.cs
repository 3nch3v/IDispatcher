namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.JobModels;

    public interface IJobService
    {
        T GetJob<T>(int id);

        IEnumerable<T> GetAll<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetRandomJobs<T>();

        int JobsCount();

        Task CreateAsync<T>(T input, string userId);

        Task DeleteAsync(int id);

        Task UpdateAsync(EditJobInputModel input, int id);

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string keyWords);

        int SearchCount();
    }
}
