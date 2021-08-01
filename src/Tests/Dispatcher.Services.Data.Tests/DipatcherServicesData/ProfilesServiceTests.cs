namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Xunit;

    public class ProfilesServiceTests
    {
        public ProfilesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ReviewDto).Assembly, typeof(CustomerReview).Assembly);
        }

        [Fact]
        public void GetUserByIdShouldReturnTheCorrectUser()
        {
            var service = this.GetService(this.GetUsersRepository());

            var user = service.GetUserById("27699db4d-e91c-4dcd-9672-7b88b8484930");

            Assert.Equal("Mux", user.FirstName);
        }

        [Fact]
        public void GetCommentsShouldReturnTheCommentForUserId()
        {
            var service = this.GetService(null, this.GetCustomersReviewsRepository());

            var user = service.GetComments<ReviewDto>(this.GetUserId());

            Assert.Equal(2, user.Count());
        }

        [Fact]
        public async Task CommentAsyncShouldAddCommentIntoDb()
        {
            var repository = this.GetCustomersReviewsRepository();
            var service = this.GetService(null, repository);
            var comment = new ReviewDto
            {
                StarsCount = 5,
                Comment = "No comment!",
                UserId = this.GetUserId(),
            };

            await service.CommentAsync<ReviewDto>("2" + this.GetUserId(), comment);
            var actualResult = repository.All().Count();

            Assert.Equal(3, actualResult);
        }

        [Fact]
        public void GetProfilePicturePathShouldReturnPictureFullPathByUserId()
        {
            var service = this.GetService(null, null, this.GetPicturesRepository());

            var actualResult = service.GetProfilePicturePath(this.GetUserId());

            Assert.Equal($"/img/profile-pictures/mypic.jpg", actualResult);
        }

        [Fact]
        public void GetUserDataShouldReturnAllAvailableDataByUserId()
        {
            var service = this.GetService(this.GetUsersRepository());

            var actualResult = service.GetUserData(this.GetUserId());

            Assert.Equal(this.GetUserId(), actualResult.Id);
        }

        private IProfilesService GetService(
            IDeletableEntityRepository<ApplicationUser> usersRepository = null,
            IDeletableEntityRepository<CustomerReview> commentsRepository = null,
            IDeletableEntityRepository<ProfilePicture> profilePicturesRepository = null,
            IFilesService filesService = null)
        {
            var service = new ProfilesService(
                usersRepository,
                commentsRepository,
                profilePicturesRepository,
                filesService);

            return service;
        }

        private EfDeletableEntityRepository<ApplicationUser> GetUsersRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            return repository;
        }

        private EfDeletableEntityRepository<CustomerReview> GetCustomersReviewsRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<CustomerReview>(dbContext);

            return repository;
        }

        private EfDeletableEntityRepository<ProfilePicture> GetPicturesRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<ProfilePicture>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            data.Users.Add(new ApplicationUser()
            {
                Id = this.GetUserId(),
                UserName = "Bratan",
                Email = "brat@bratan.bg",
                PasswordHash = Guid.NewGuid().ToString(),
                ProfilePicture = new ProfilePicture
                {
                    Id = "mypic",
                    Extension = ".jpg",
                },
            });

            data.Users.Add(new ApplicationUser()
            {
                Id = "2" + this.GetUserId(),
                UserName = "Jica",
                Email = "jic@fake.bg",
                PasswordHash = Guid.NewGuid().ToString(),
                FirstName = "Mux",
            });

            data.CustomersReviews.Add(
                new CustomerReview
                {
                    StarsCount = 5,
                    Comment = "The best one!",
                    UserId = this.GetUserId(),
                    AppraiserId = "2" + this.GetUserId(),
                });

            data.CustomersReviews.Add(
                new CustomerReview
                {
                    StarsCount = 3,
                    Comment = "Not so good",
                    UserId = this.GetUserId(),
                    AppraiserId = "2" + this.GetUserId(),
                });

            await data.SaveChangesAsync();

            return data;
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        public class ReviewDto : IMapFrom<CustomerReview>, IMapTo<CustomerReview>
        {
            public int StarsCount { get; set; }

            public string Comment { get; set; }

            public string UserId { get; set; }

            public string AppraiserId { get; set; }
        }
    }
}
