namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;
    using Xunit;

    public class CommentsServiceTests : BaseServiceTests
    {
        [Theory]
        [InlineData(5)]
        public async Task CreateAsyncShouldAddNewCommentInDb(int id)
        {
            var service = GetCommentService(CommentsServiceRepository);
            var input = this.GetCommentInputModel();

            await service.CreateAsync<PostInputViewModel>(input, UserId);
            var actualUserID = service.GetCreatorId(id);

            Assert.Equal(UserId, actualUserID);
        }

        [Theory]
        [InlineData(1, 3)]
        public async Task DeleteShouldWorkProperly(int id, int expectedCount)
        {
            var repository = CommentsServiceRepository;
            var service = GetCommentService(repository);

            await service.DeleteAsync(id);
            var actualCount = repository.All().Count();

            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(1)]
        public void GetCreatorShouldReturnCorrectUserId(int id)
        {
            var service = GetCommentService(CommentsServiceRepository);

            var actualUserId = service.GetCreatorId(id);

            Assert.Equal(UserId, actualUserId);
        }
    }
}
