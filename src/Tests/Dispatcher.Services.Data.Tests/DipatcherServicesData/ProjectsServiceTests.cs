namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ProjectModels;
    using Xunit;

    public class ProjectsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldAddNewProjectInDb()
        {
            var repository = ProjectsRepository;
            var service = GetService(repository);
            var input = this.GetProjectInputModel();

            await service.CreateAsync<ProjectInputmodel>(input, UserId);
            var actualCount = repository.All().Count();

            int expectedCount = 5;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(2)]
        public async Task UpdateAsyncShouldChangeTheProjectContainWhenTheInputDataIsDifferent(int id)
        {
            var service = GetService(ProjectsRepository);
            var input = this.GetProjectInputModel();

            await service.UpdateAsync<ProjectInputmodel>(input, id);
            var actualResult = service.GetById<SingleProjectViewModel>(id);

            Assert.Equal("Input", actualResult.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteShouldWorkProperly(int id)
        {
            var repository = ProjectsRepository;
            var service = GetService(repository);

            await service.DeleteAsync(id);
            var actualCount = repository.All().Count();

            int expectedCount = 3;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(3)]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenProjectId(int id)
        {
            var service = GetService(ProjectsRepository);

            var actual = service.GetById<SingleProjectViewModel>(id);

            string expectedName = "Test3";
            Assert.Equal(expectedName, actual.Name);
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = GetService(ProjectsRepository);

            var actualUserId = service.GetCreatorId(4);

            Assert.Equal(UserId, actualUserId);
        }
    }
}
