namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.BlogModels;
    using Xunit;

    using static Dispatcher.Common.GlobalConstants.Blog;

    public class BlogsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldAddBlogSuccessfully()
        {
            var service = GetBlogService(BlogsRepository);
            var newBlog = GetBlogInputModel();

            await service.CreateAsync<BlogInputModel>(newBlog, UserId, null, BlogPicturePath, null);
            var actualCount = service.BlogPostsCount();

            int expectedCount = 5;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateAsyncShouldModifyBlogWhenDataInputIsDifferent(int id)
        {
            var service = GetBlogService(BlogsRepository);
            var input = GetBlogInputModel();

            await service.UpdateAsync<BlogInputModel>(input, id, null, BlogPicturePath, null);
            var actualResult = service.GetById<BlogPostViewModel>(id);

            Assert.Equal("Input", actualResult.Title);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteShouldWorkProperly(int id)
        {
            var service = GetBlogService(BlogsRepository);

            await service.DeleteAsync(id);
            var actualCount = service.BlogPostsCount();

            int expectedCount = 3;
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void BlogPostsCountShouldReturnTheCounOfTheBlogs()
        {
            var service = GetBlogService(BlogsRepository);

            var actualCount = service.BlogPostsCount();

            int expectedCount = 4;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(3)]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenBlogId(int id)
        {
            var service = GetBlogService(BlogsRepository);

            var actualAd = service.GetById<BlogPostViewModel>(id);

            Assert.Equal(id, actualAd.Id);
            Assert.Equal("Test3", actualAd.Title);
            Assert.Equal("fake", actualAd.UserUsername);
        }

        [Theory]
        [InlineData(1, 5, 4)]
        public void GetAllShouldReturnRequestedBlogs(int page, int entitiesCount, int expectedCount)
        {
            var service = GetBlogService(BlogsRepository);

            var actualAds = service.GetAllBlogPosts<BlogPostViewModel>(page, entitiesCount);

            Assert.Equal(expectedCount, actualAds.Count());
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = GetBlogService(BlogsRepository);

            var actualUserId = service.GetCreatorId(2);

            Assert.Equal(UserId, actualUserId);
        }
    }
}
