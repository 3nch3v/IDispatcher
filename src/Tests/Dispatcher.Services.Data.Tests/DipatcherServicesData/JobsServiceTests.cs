namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.JobModels;
    using Xunit;

    public class JobsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldAddNewJobInDb()
        {
            var service = GetService(JobsRepository);
            var input = this.GetJobInputModel();

            await service.CreateAsync<JobInputModel>(input, UserId);
            var actualCount = service.JobsCount();

            int expectedResult = 5;
            Assert.Equal(expectedResult, actualCount);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateAsyncShouldChangeJobTitle(int id)
        {
            var service = GetService(JobsRepository);
            var input = this.GetJobInputModel();

            await service.UpdateAsync<JobInputModel>(input, id);
            var actualResult = service.GetById<SigleJobViewModel>(id);

            Assert.Equal(input.Title, actualResult.Title);
            Assert.Equal(input.Location, actualResult.Location);
            Assert.Equal(input.Contact, actualResult.Contact);
            Assert.Equal(input.CompanyName, actualResult.CompanyName);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteShouldWorkProperly(int id)
        {
            var service = GetService(JobsRepository);

            await service.DeleteAsync(id);
            var actualCount = service.JobsCount();

            int expectedCount = 3;
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void JobsCountShouldReturnAllJobsCountInDb()
        {
            var service = GetService(JobsRepository);

            var actualCount = service.JobsCount();

            int expectedCount = 4;
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenJobId()
        {
            var service = GetService(JobsRepository);

            var result = service.GetById<SigleJobViewModel>(2);

            Assert.Equal("Test2", result.Title);
        }

        [Theory]
        [InlineData(1, 5, 4)]
        public void GetAllShouldReturnCountEntitiesPerPageJobsInDb(int page, int entities, int expectedCount)
        {
            var service = GetService(JobsRepository);

            var actualAds = service.GetAll<SigleJobViewModel>(page, entities);

            Assert.Equal(expectedCount, actualAds.Count());
        }

        [Theory]
        [InlineData(1)]
        public void GetCreatorShouldReturnCorrectUserId(int id)
        {
            var service = GetService(JobsRepository);

            var actualUserId = service.GetCreatorId(id);

            Assert.Equal(UserId, actualUserId);
        }

        [Theory]
        [InlineData(1, 5, "Test3")]
        public void SearchShouldReturnAllAdsWithTheGivenTerms(int page, int entities, string searchTerm)
        {
            var service = GetService(JobsRepository);

            var actualResult = service.SearchResults<SigleJobViewModel>(page, entities, searchTerm);
            var searchCountResult = service.SearchCount();

            Assert.Single(actualResult);
            Assert.Equal(1, searchCountResult);
        }
    }
}
