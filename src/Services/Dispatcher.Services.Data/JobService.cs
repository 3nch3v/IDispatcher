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

        public async Task DeleteAsync(int id)
        {
            var job = this.jobRepository.All().FirstOrDefault(j => j.Id == id);
            this.jobRepository.Delete(job);
            await this.jobRepository.SaveChangesAsync();
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
            var job = this.jobRepository
                .AllAsNoTracking()
                .Where(j => j.Id == id)
                .To<T>()
                .FirstOrDefault();

            return job;
        }
    }
}
