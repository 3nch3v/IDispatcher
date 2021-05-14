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

        public JobsService(IDeletableEntityRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task CreateAsync(JobInputModel input, string userId)
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
