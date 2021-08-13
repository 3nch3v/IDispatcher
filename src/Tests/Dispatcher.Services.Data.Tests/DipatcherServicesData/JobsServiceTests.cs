namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Microsoft.Extensions.Caching.Memory;
    using Xunit;

    public class JobsServiceTests
    {
        public JobsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(JobDto).Assembly, typeof(Job).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewJobInDb()
        {
            var service = this.GetService(this.GetJobsRepository());
            var newAd = this.GetInputModel();

            await service.CreateAsync<JobInputModel>(newAd, this.GetUserId());
            var actualCount = service.JobsCount();

            Assert.Equal(5, actualCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeJobTitle()
        {
            var service = this.GetService(this.GetJobsRepository());
            var updateModel = this.GetInputModel();

            await service.UpdateAsync<JobInputModel>(updateModel, 1);
            var actualResult = service.GetById<JobDto>(1);

            Assert.Equal("Input", actualResult.Title);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeJobBody()
        {
            var service = this.GetService(this.GetJobsRepository());
            var updateModel = this.GetInputModel();

            await service.UpdateAsync<JobInputModel>(updateModel, 1);
            var actualResult = service.GetById<JobDto>(1);

            Assert.Equal(updateModel.JobBody, actualResult.JobBody);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var service = this.GetService(this.GetJobsRepository());

            await service.DeleteAsync(1);
            var actualCount = service.JobsCount();

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void JobsCountShouldReturnAllJobsCountInDb()
        {
            var service = this.GetService(this.GetJobsRepository());

            var actualCount = service.JobsCount();

            Assert.Equal(4, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenJobId()
        {
            var service = this.GetService(this.GetJobsRepository());

            var actualAd = service.GetById<JobDto>(2);

            Assert.Equal("Test2", actualAd.Title);
        }

        [Fact]
        public void GetAllShouldReturnCountEntitiesPerPageJobsInDb()
        {
            var service = this.GetService(this.GetJobsRepository());

            var actualAds = service.GetAll<JobDto>(1, 5);

            Assert.Equal(4, actualAds.Count());
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = this.GetService(this.GetJobsRepository());

            var actualUserId = service.GetCreatorId(1);

            Assert.Equal("7699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        [Fact]
        public void SearchShouldReturnAllAdsWithTheGivenTerms()
        {
            var service = this.GetService(this.GetJobsRepository());

            var actualResult = service.SearchResults<JobDto>(1, 5, "Test3");
            var actualSearchCount = service.SearchCount();
            var actualAd = actualResult.FirstOrDefault();

            Assert.Equal(1, actualSearchCount);
            Assert.Equal(3, actualAd.Id);
        }

        private IJobsService GetService(
            IDeletableEntityRepository<Job> jobRepository = null,
            IMemoryCache memoryCache = null)
        {
            var service = new JobsService(jobRepository, memoryCache);

            return service;
        }

        private EfDeletableEntityRepository<Job> GetJobsRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Job>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            data.Jobs.Add(new Job()
            {
                Id = 1,
                Title = "Test1",
                JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Mercedes",
                Location = "Stuttgart, DE",
                LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Jobs.Add(new Job()
            {
                Id = 2,
                Title = "Test2",
                JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Audi",
                Location = "Ingolstadt, DE",
                LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Jobs.Add(new Job()
            {
                Id = 3,
                Title = "Test3",
                JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "BMW",
                Location = "Munich, DE",
                LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Jobs.Add(new Job()
            {
                Id = 4,
                Title = "Test4",
                JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Mercedes",
                Location = "Stuttgart, DE",
                LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });

            await data.SaveChangesAsync();

            return data;
        }

        private JobInputModel GetInputModel()
        {
            return new JobInputModel()
            {
                Title = "Input",
                JobBody = "Edit We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Bla-Bla",
                Location = "Sofia, Razsadnika",
                Contact = "fake@fake.bg",
            };
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        public class JobDto : IMapFrom<Job>
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string JobBody { get; set; }

            public string CompanyName { get; set; }

            public string Location { get; set; }

            public string Contact { get; set; }

            public string UserId { get; set; }
        }

        public class JobInputModel : IMapTo<Job>
        {
            public string Title { get; set; }

            public string JobBody { get; set; }

            public string CompanyName { get; set; }

            public string Location { get; set; }

            public string Contact { get; set; }
        }
    }
}
