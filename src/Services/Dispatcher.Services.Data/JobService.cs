namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class JobService : IJobService
    {
        private readonly IDeletableEntityRepository<Job> jobRepository;

        public JobService(IDeletableEntityRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public Task CreateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync<T>()
        {
             var jobs = this.jobRepository
                .AllAsNoTracking()
                .OrderByDescending(j => j.CreatedOn)
                .To<T>()
                .ToList();

             return jobs;
        }

        public T GetJob<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
