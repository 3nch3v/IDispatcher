namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class JobsService : IJobService
    {
        private readonly IDeletableEntityRepository<Job> jobRepository;
        private int searchResultCount;

        public JobsService(IDeletableEntityRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task CreateAsync<T>(T input, string id)
        {
            var job = AutoMapperConfig.MapperInstance.Map<Job>(input);
            job.UserId = id;

            await this.jobRepository.AddAsync(job);
            await this.jobRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id)
        {
            var updatedJob = AutoMapperConfig.MapperInstance.Map<Job>(input);
            var job = this.jobRepository.All().FirstOrDefault(j => j.Id == id);
            job.Title = updatedJob.Title;
            job.JobBody = updatedJob.JobBody;
            job.CompanyName = updatedJob.CompanyName;
            job.Location = updatedJob.Location;
            job.Contact = updatedJob.Contact;
            job.LogoUrl = updatedJob.LogoUrl;

            await this.jobRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var job = this.jobRepository.All().FirstOrDefault(j => j.Id == id);
            this.jobRepository.Delete(job);
            await this.jobRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var job = this.jobRepository
                .AllAsNoTracking()
                .Where(j => j.Id == id)
                .To<T>()
                .FirstOrDefault();

            return job;
        }

        public IEnumerable<T> GetAll<T>(int page, int pageEntitiesCount)
        {
             var jobs = this.jobRepository
                .AllAsNoTracking()
                .OrderByDescending(j => j.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

             return jobs;
        }

        public IEnumerable<T> GetRandomJobs<T>()
        {
            var jobs = this.jobRepository
               .AllAsNoTracking()
               .OrderByDescending(j => Guid.NewGuid())
               .To<T>()
               .Take(3)
               .ToList();

            return jobs;
        }

        public IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string keyWords)
        {
            string[] searchingKeyWords = keyWords.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var query = this.jobRepository.All().AsQueryable();

            foreach (var word in searchingKeyWords)
            {
                query = query.Where(j => j.Title.ToLower().Contains(word)
                                    || j.JobBody.ToLower().Contains(word)
                                    || j.Location.ToLower().Contains(word));
            }

            this.searchResultCount = query
                .To<T>()
                .ToList().Count();

            var result = query
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return result;
        }

        public int JobsCount()
        {
            return this.jobRepository.AllAsNoTracking().Count();
        }

        public int SearchCount()
        {
            return this.searchResultCount;
        }
    }
}
