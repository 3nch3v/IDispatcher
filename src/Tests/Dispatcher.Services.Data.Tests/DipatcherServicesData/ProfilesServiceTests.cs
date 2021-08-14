namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ProfileModels;
    using Xunit;

    public class ProfilesServiceTests : BaseServiceTests
    {
        [Fact]
        public void GetUserByIdShouldReturnTheCorrectUser()
        {
            var service = GetService(UsersRepository);

            var user = service.GetUserById(UserId);

            Assert.Equal(UserId, user.Id);
        }

        [Fact]
        public void GetCommentsShouldReturnAllCommentsForrequestedUserId()
        {
            var service = GetService(null, CustomersReviewsRepository);

            var user = service.GetComments<CommentViewModel>(UserId);

            Assert.Equal(2, user.Count());
        }

        [Fact]
        public async Task CommentAsyncShouldAddCommentIntoDb()
        {
            var repository = CustomersReviewsRepository;
            var service = GetService(null, repository);
            var input = this.GetReviewInputModel();
            string forUserId = "2" + UserId;

            await service.CommentAsync<CommentInputModel>(forUserId, input);
            var actualResult = repository.All().Count();

            int expextecCount = 3;
            Assert.Equal(expextecCount, actualResult);
        }

        [Fact]
        public void GetProfilePicturePathShouldReturnPictureFullPathByUserId()
        {
            var service = GetService(null, null, PicturesRepository);

            var actualResult = service.GetProfilePicturePath(UserId);

            Assert.Equal($"/img/profile-pictures/mypic.jpg", actualResult);
        }

        [Fact]
        public void GetUserDataShouldReturnAllAvailableDataByUserId()
        {
            var service = GetService(UsersRepository);

            var actualResult = service.GetUserData(UserId);

            Assert.Equal(UserId, actualResult.Id);
        }
    }
}
