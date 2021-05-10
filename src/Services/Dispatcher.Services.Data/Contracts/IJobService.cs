namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.JobModels;

    public interface IJobService
    {
        T GetJob<T>(int id);

        IEnumerable<T> GetAllAsync<T>();

        IEnumerable<T> GetRandomJobs<T>();

        Task CreateAsync(JobInputModel input, string userId);

        Task DeleteAsync(int id);

        Task UpdateAsync(EditJobInputModel input, int id);
    }
}
