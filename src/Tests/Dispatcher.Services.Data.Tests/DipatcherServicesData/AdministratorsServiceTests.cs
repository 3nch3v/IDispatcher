namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Microsoft.Extensions.Caching.Memory;
    using Xunit;

    public class AdministratorsServiceTests
    {
        private static string UserId => "7699db4d-e91c-4dcd-9672-7b88b8484930";

        [Fact]
        public void GetDataShouldReturnCorrectEntitybyCall()
        {
            var dbContext = this.PrepareDb().Result;
            var adsRepository = new EfDeletableEntityRepository<Advertisement>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);
            var jobsRepository = new EfDeletableEntityRepository<Job>(dbContext);
            var blogsRepository = new EfDeletableEntityRepository<Blog>(dbContext);
            var discussionsRepository = new EfDeletableEntityRepository<Discussion>(dbContext);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(dbContext);
            var customersReviewsRepository = new EfDeletableEntityRepository<CustomerReview>(dbContext);
            var profilePicturesRepository = new EfDeletableEntityRepository<ProfilePicture>(dbContext);
            var projectsRepository = new EfDeletableEntityRepository<Project>(dbContext);
            var service = this.GetService(
                                    adsRepository,
                                    usersRepository,
                                    jobsRepository,
                                    blogsRepository,
                                    discussionsRepository,
                                    commentsRepository,
                                    customersReviewsRepository,
                                    profilePicturesRepository,
                                    projectsRepository);

            var userResult = service.GetData("User", "Id", UserId).Data.FirstOrDefault().Id;
            var adResult = service.GetData("Advertisement", "Id", "1").Data.FirstOrDefault().Title;
            var jobResult = service.GetData("Job", "Id", "1").Data.FirstOrDefault().Title;
            var forumResult = service.GetData("ForumPost", "Title", "Test2").Data.FirstOrDefault().Id;
            var blogResult = service.GetData("BlogPost", "Title", "The Blog").Data.FirstOrDefault().Id;
            var reviewResult = service.GetData("Review", "Username", "Delete").Data.FirstOrDefault().Id;
            var commentResult = service.GetData("ForumComment", "Id", "2").Data.FirstOrDefault().Content;

            Assert.Equal(UserId, userResult);
            Assert.Equal("Test1", adResult);
            Assert.Equal("The Job", jobResult);
            Assert.Equal("2", forumResult);
            Assert.Equal("1", blogResult);
            Assert.Equal("1", reviewResult);
            Assert.Equal("Super Dev", commentResult);
        }

        [Fact]
        public async Task DeleteUserAsyncShouldSoftDeleteTheUserAndUsersData()
        {
            var dbContext = this.PrepareDb().Result;
            var adsRepository = new EfDeletableEntityRepository<Advertisement>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);
            var jobsRepository = new EfDeletableEntityRepository<Job>(dbContext);
            var blogsRepository = new EfDeletableEntityRepository<Blog>(dbContext);
            var discussionsRepository = new EfDeletableEntityRepository<Discussion>(dbContext);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(dbContext);
            var customersReviewsRepository = new EfDeletableEntityRepository<CustomerReview>(dbContext);
            var profilePicturesRepository = new EfDeletableEntityRepository<ProfilePicture>(dbContext);
            var projectsRepository = new EfDeletableEntityRepository<Project>(dbContext);
            var service = this.GetService(
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
            var expectedUsersCount = dbContext.Users.Where(u => u.Id == UserId).Count();
            var expectedAdsCount = dbContext.Advertisements.Where(u => u.UserId == UserId).Count();
            var expectedJobsCount = dbContext.Jobs.Where(u => u.UserId == UserId).Count();
            var expectedDiscussionssCount = dbContext.Discussions.Where(u => u.UserId == UserId).Count();
            var expectedBlogssCount = dbContext.Blogs.Where(u => u.UserId == UserId).Count();
            var expectedProjectsCount = dbContext.Projects.Where(u => u.UserId == UserId).Count();
            var expectedCustomerReviewsCount = dbContext.CustomersReviews.Where(u => u.UserId == UserId).Count();
            var expectedProfilePicturesCount = dbContext.ProfilesPictures.Where(u => u.UserId == UserId).Count();
            var expectedCommentsCount = dbContext.Comments.Where(u => u.UserId == UserId).Count();

            Assert.Equal(0, expectedUsersCount);
            Assert.Equal(0, expectedAdsCount);
            Assert.Equal(0, expectedJobsCount);
            Assert.Equal(0, expectedDiscussionssCount);
            Assert.Equal(0, expectedBlogssCount);
            Assert.Equal(0, expectedProjectsCount);
            Assert.Equal(0, expectedCustomerReviewsCount);
            Assert.Equal(0, expectedProfilePicturesCount);
            Assert.Equal(0, expectedCommentsCount);
        }

        [Fact]
        public async Task DeleteReviewAsyncShuldDeleteReviewByGivenId()
        {
            var dbContext = this.PrepareDb().Result;
            var customersReviewsRepository = new EfDeletableEntityRepository<CustomerReview>(dbContext);
            var service = this.GetService(null, null, null, null, null, null, customersReviewsRepository, null, null);

            await service.DeleteReviewAsync(1);

            var actualReviewsCount = dbContext.CustomersReviews.Count();
            Assert.Equal(1, actualReviewsCount);
        }

        private IAdministartorsServices GetService(
            IDeletableEntityRepository<Advertisement> advertisementsRepository = null,
            IDeletableEntityRepository<ApplicationUser> usersRepository = null,
            IDeletableEntityRepository<Job> jobRepository = null,
            IDeletableEntityRepository<Blog> blogRepository = null,
            IDeletableEntityRepository<Discussion> discussionsRepository = null,
            IDeletableEntityRepository<Comment> commentsRepository = null,
            IDeletableEntityRepository<CustomerReview> customersReviesRepository = null,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository = null,
            IDeletableEntityRepository<Project> projectsRepository = null,
            IMemoryCache memoryCache = null)
        {
            var service = new AdministartorsServices(
                advertisementsRepository,
                usersRepository,
                jobRepository,
                blogRepository,
                discussionsRepository,
                commentsRepository,
                customersReviesRepository,
                profilePicturesRepository,
                projectsRepository,
                memoryCache);

            return service;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;

            var user = new ApplicationUser
            {
                Id = UserId,
                UserName = "Delete",
                Email = "delete@fake.bg",
                PasswordHash = Guid.NewGuid().ToString(),
            };

            await data.Users.AddAsync(user);

            data.Advertisements.Add(new Advertisement()
            {
                Id = 1,
                AdvertisementTypeId = 1,
                Title = "Test1",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "200",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Advertisements.Add(new Advertisement()
            {
                Id = 2,
                AdvertisementTypeId = 2,
                Title = "Test2",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "100",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });

            data.Jobs.Add(new Job()
            {
                Id = 1,
                Title = "The Job",
                JobBody = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                CompanyName = "Mercedes",
                Location = "Stuttgart, DE",
                LogoUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });

            await data.Blogs.AddAsync(new Blog
                {
                    Id = 1,
                    Title = "The Blog",
                    Body = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                    UserId = UserId,
                });
            await data.Blogs.AddAsync(new Blog
               {
                   Id = 2,
                   Title = "Test2",
                   Body = "2 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s2",
                   UserId = "1" + UserId,
               });

            data.Discussions.Add(new Discussion()
            {
                Id = 1,
                Title = "Test1",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 1,
                IsSolved = false,
            });

            var discussion = new Discussion()
            {
                Id = 2,
                Title = "Test2",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 3,
                IsSolved = false,
            };

            data.Discussions.Add(discussion);

            await data.Comments.AddAsync(new Comment
               {
                   Id = 1,
                   Content = "The best one",
                   User = user,
                   Discussion = discussion,
               });
            await data.Comments.AddAsync(new Comment
                {
                    Id = 2,
                    Content = "Super Dev",
                    User = user,
                    Discussion = discussion,
                });

            await data.Projects.AddAsync(new Project
                {
                    Id = 1,
                    Name = "Test1",
                    Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                    UserRole = "Teacher",
                    UserId = UserId,
                });

            await data.CustomersReviews.AddAsync(
                new CustomerReview
                {
                    Id = 1,
                    AppraiserId = UserId,
                    StarsCount = 5,
                    Comment = "Ok",
                    User = user,
                });

            await data.CustomersReviews.AddAsync(
                new CustomerReview
                {
                    Id = 2,
                    AppraiserId = UserId,
                    StarsCount = 1,
                    Comment = "Bad",
                    User = user,
                });

            await data.SaveChangesAsync();

            return data;
        }
    }
}
