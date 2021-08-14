namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Data.Repositories;
    using Xunit;

    public class AdministratorsServiceTests : BaseServiceTests
    {
        [Fact]
        public void GetDataShouldReturnCorrectEntitybyCall()
        {
            var service = GetService(
                     AdsRepository,
                     UsersRepository,
                     JobsRepository,
                     BlogsRepository,
                     ForumRepository,
                     CommentsServiceRepository,
                     CustomersReviewsRepository,
                     PicturesRepository,
                     ProjectsRepository);

            var userResult = service.GetData("User", "Id", UserId).Data.FirstOrDefault().Id;
            var adResult = service.GetData("Advertisement", "Id", "1").Data.FirstOrDefault().Title;
            var jobResult = service.GetData("Job", "Id", "1").Data.FirstOrDefault().Title;
            var forumResult = service.GetData("ForumPost", "Title", "Test2").Data.FirstOrDefault().Id;
            var blogResult = service.GetData("BlogPost", "Title", "Test4").Data.FirstOrDefault().Id;
            var reviewResult = service.GetData("Review", "Username", "fake").Data.FirstOrDefault().Id;
            var commentResult = service.GetData("ForumComment", "Id", "2").Data.FirstOrDefault().Content;

            Assert.Equal(UserId, userResult);
            Assert.Equal("Test1", adResult);
            Assert.Equal("Test1", jobResult);
            Assert.Equal("2", forumResult);
            Assert.Equal("4", blogResult);
            Assert.Equal("1", reviewResult);
            Assert.Equal("Super Dev", commentResult);
        }

        [Fact]
        public async Task DeleteUserAsyncShouldSoftDeleteTheUserAndUsersData()
        {
            var dbContext = PrepareDb().Result;
            var adsRepository = new EfDeletableEntityRepository<Advertisement>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);
            var jobsRepository = new EfDeletableEntityRepository<Job>(dbContext);
            var blogsRepository = new EfDeletableEntityRepository<Blog>(dbContext);
            var discussionsRepository = new EfDeletableEntityRepository<Discussion>(dbContext);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(dbContext);
            var customersReviewsRepository = new EfDeletableEntityRepository<CustomerReview>(dbContext);
            var profilePicturesRepository = new EfDeletableEntityRepository<ProfilePicture>(dbContext);
            var projectsRepository = new EfDeletableEntityRepository<Project>(dbContext);

            var service = GetService(
                        adsRepository,
                        usersRepository,
                        jobsRepository,
                        blogsRepository,
                        discussionsRepository,
                        commentsRepository,
                        customersReviewsRepository,
                        profilePicturesRepository,
                        projectsRepository);

            await service.DeleteUserAsync(UserId);

            var actualUsersCount = dbContext.Users.Where(u => u.Id == UserId).Count();
            var actualAdsCount = dbContext.Advertisements.Where(u => u.UserId == UserId).Count();
            var actualJobsCount = dbContext.Jobs.Where(u => u.UserId == UserId).Count();
            var actualDiscussionssCount = dbContext.Discussions.Where(u => u.UserId == UserId).Count();
            var actualBlogssCount = dbContext.Blogs.Where(u => u.UserId == UserId).Count();
            var actualProjectsCount = dbContext.Projects.Where(u => u.UserId == UserId).Count();
            var actualCustomerReviewsCount = dbContext.CustomersReviews.Where(u => u.UserId == UserId).Count();
            var actualProfilePicturesCount = dbContext.ProfilesPictures.Where(u => u.UserId == UserId).Count();
            var actualCommentsCount = dbContext.Comments.Where(u => u.UserId == UserId).Count();

            int expexted = 0;
            Assert.Equal(expexted, actualUsersCount);
            Assert.Equal(expexted, actualAdsCount);
            Assert.Equal(expexted, actualJobsCount);
            Assert.Equal(expexted, actualDiscussionssCount);
            Assert.Equal(expexted, actualBlogssCount);
            Assert.Equal(expexted, actualProjectsCount);
            Assert.Equal(expexted, actualCustomerReviewsCount);
            Assert.Equal(expexted, actualProfilePicturesCount);
            Assert.Equal(expexted, actualCommentsCount);
        }

        [Fact]
        public async Task DeleteReviewAsyncShuldDeleteReviewByGivenId()
        {
            var dbContext = PrepareDb().Result;
            var customersReviewsRepository = new EfDeletableEntityRepository<CustomerReview>(dbContext);
            var service = GetService(null, null, null, null, null, null, customersReviewsRepository, null, null);

            await service.DeleteReviewAsync(1);

            var actualReviewsCount = dbContext.CustomersReviews.Count();
            Assert.Equal(1, actualReviewsCount);
        }
    }
}
