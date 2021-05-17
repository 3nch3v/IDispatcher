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
    using Dispatcher.Web.ViewModels.JobModels;

    public class JobsService : IJobService
    {
        private readonly IDeletableEntityRepository<Job> jobRepository;
        private int searchResultCount;

        public JobsService(IDeletableEntityRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task CreateAsync<T>(T input, string userId)
        {
            var job = AutoMapperConfig.MapperInstance.Map<Job>(input);
            job.UserId = userId;

            await this.jobRepository.AddAsync(job);
            await this.jobRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var job = this.jobRepository.All().FirstOrDefault(j => j.Id == id);
            this.jobRepository.Delete(job);
            await this.jobRepository.SaveChangesAsync();
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

        public T GetJob<T>(int id)
        {
            var job = this.jobRepository
                .AllAsNoTracking()
                .Where(j => j.Id == id)
                .To<T>()
                .FirstOrDefault();

            return job;
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

        public int JobsCount()
        {
            return this.jobRepository.AllAsNoTracking().Count();
        }

        public int SearchCount()
        {
            return this.searchResultCount;
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

        public async Task UpdateAsync(EditJobInputModel input, int id)
        {
            var job = this.jobRepository.All().FirstOrDefault(j => j.Id == id);
            job.Title = input.Title;
            job.JobBody = input.JobBody;
            job.CompanyName = input.CompanyName;
            job.Location = input.Location;
            job.Contact = input.Contact;
            job.LogoUrl = input.LogoUrl;

            await this.jobRepository.SaveChangesAsync();
        }
    }
}
