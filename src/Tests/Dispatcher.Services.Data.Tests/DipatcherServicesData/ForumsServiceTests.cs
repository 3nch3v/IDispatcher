namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;
    using Xunit;

    public class ForumsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldAddNewDiscussionSuccessfully()
        {
            var service = GetForumService(ForumRepository);
            var input = this.GetDiscussionInputModel();

            await service.CreateAsync<DiscussionInputModel>(input, UserId);
            var actualCount = service.GetDiscussionsCount("All");

            int expectedCount = 5;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateAsyncShouldChangeDiscussionDataWhenTheInputContainsDifferentInformation(int id)
        {
            var service = GetForumService(ForumRepository, CategoriesRepository);
            var updateModel = this.GetDiscussionInputModel();

            await service.UpdateAsync<DiscussionInputModel>(updateModel, id);
            var actualResult = service.GetById<SingleForumDiscussionsTestViewModel>(id);

            Assert.Equal("Input", actualResult.Title);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteShouldWorkProperly(int id)
        {
            var service = GetForumService(ForumRepository);

            await service.DeleteAsync(id);
            var actualCount = service.GetDiscussionsCount("All");

            int expectedCount = 3;
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void GetDiscussionsCountShouldReturnTheCountOfAllDiscussions()
        {
            var service = GetForumService(ForumRepository);

            var actualCount = service.GetDiscussionsCount("All");

            int expectedCount = 4;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(3, "News")]
        public void GetDiscussionsCountShouldReturnDiscussionsCountByCategory(int expectedCount, string category)
        {
            var service = GetForumService(ForumRepository);

            var actualCount = service.GetDiscussionsCount(category);

            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(3)]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenId(int id)
        {
            var service = GetForumService(ForumRepository);

            var actualDiscussion = service.GetById<SingleForumDiscussionsTestViewModel>(id);

            Assert.Equal("Test3", actualDiscussion.Title);
        }

        [Theory]
        [InlineData(1, 5, "All", 4)]
        [InlineData(1, 5, "Unsolved", 4)]
        [InlineData(1, 5, "News", 3)]
        public void GetAllShouldReturnAllDiscussions(int page, int entities, string category, int expextedCount)
        {
            var service = GetForumService(ForumRepository);

            var actualDuscussions = service.GetAllForumDiscussions<SingleForumDiscussionsTestViewModel>(page, entities, category);

            Assert.Equal(expextedCount, actualDuscussions.Count());
        }

        [Theory]
        [InlineData(3)]
        public void GetCreatorShouldReturnCorrectUserId(int id)
        {
            var service = GetForumService(ForumRepository);

            var actualUserId = service.GetCreatorId(id);

            Assert.Equal(UserId, actualUserId);
        }

        [Fact]
        public void GetCategoriesShouldReturnListWithAllCategoriesInDb()
        {
            var service = GetForumService(null, CategoriesRepository);

            var actualTypes = service.GetCategories<SingleCategoryViewModel>();

            int expectedCount = 3;
            Assert.Equal(expectedCount, actualTypes.Count());
        }

        [Fact]
        public async Task SetDiscusionToSolvedShouldChangeTheDiscussionStatusInTheDbToTrue()
        {
            var repository = ForumRepository;
            var service = GetForumService(repository);

            await service.SetDiscussionToSolvedAsync(1);
            var result = service.GetById<SingleForumDiscussionsTestViewModel>(1);

            Assert.True(result.IsSolved);
        }
    }
}
