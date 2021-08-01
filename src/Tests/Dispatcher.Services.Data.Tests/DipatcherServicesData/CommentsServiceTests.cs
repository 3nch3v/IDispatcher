namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Xunit;

    public class CommentsServiceTests
    {
        public CommentsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(CommentInputModel).Assembly, typeof(Comment).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewCommentInDb()
        {
            var service = this.GetService(this.GetCommentsServiceRepository());
            var newComment = this.GetInputModel();

            await service.CreateAsync<CommentInputModel>(newComment, this.GetUserId());
            var actualUserID = service.GetCreatorId(5);

            Assert.Equal(this.GetUserId(), actualUserID);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var repository = this.GetCommentsServiceRepository();
            var service = this.GetService(repository);

            await service.DeleteAsync(1);
            var actualCount = repository.All().Count();

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = this.GetService(this.GetCommentsServiceRepository());

            var actualUserId = service.GetCreatorId(2);

            Assert.Equal("77699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        private ICommentsService GetService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            var service = new CommentsService(commentsRepository);

            return service;
        }

        private EfDeletableEntityRepository<Comment> GetCommentsServiceRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Comment>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            await data.Comments.AddAsync(
                new Comment
                {
                    Id = 1,
                    Content = "The best one",
                    UserId = this.GetUserId(),
                    DiscussionId = 1,
                });
            await data.Comments.AddAsync(
                new Comment
                {
                    Id = 2,
                    Content = "Super Dev",
                    UserId = "7" + this.GetUserId(),
                    DiscussionId = 2,
                });
            await data.Comments.AddAsync(
                new Comment
                {
                    Id = 3,
                    Content = "Number one! The best one",
                    UserId = this.GetUserId(),
                    DiscussionId = 2,
                });
            await data.Comments.AddAsync(
                new Comment
                {
                    Id = 4,
                    Content = "Super! The best one",
                    UserId = this.GetUserId(),
                    DiscussionId = 3,
                });

            await data.SaveChangesAsync();

            return data;
        }

        private CommentInputModel GetInputModel()
        {
            return new CommentInputModel()
            {
                UserId = this.GetUserId(),
                DiscussionId = 1,
                Content = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
            };
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        public class CommentInputModel : IMapTo<Comment>
        {
            public string UserId { get; set; }

            public int DiscussionId { get; set; }

            public string Content { get; set; }
        }
    }
}
