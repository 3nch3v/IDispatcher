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

    public class ForumsServiceTests
    {
        public ForumsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(DicussionDto).Assembly, typeof(Discussion).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewDiscussionInDb()
        {
            var service = this.GetService(this.GetForumRepository());
            var newDiscussion = this.GetInputModel();

            await service.CreateAsync<DiscussionInputModel>(newDiscussion, this.GetUserId());
            var actualCount = service.GetDiscussionsCount("All");

            Assert.Equal(5, actualCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeDiscussionTitleInDb()
        {
            var service = this.GetService(this.GetForumRepository());
            var updateModel = this.GetInputModel();

            await service.UpdateAsync<DiscussionInputModel>(updateModel, 1);
            var actualResult = service.GetById<DicussionDto>(1);

            Assert.Equal("Input", actualResult.Title);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var service = this.GetService(this.GetForumRepository());

            await service.DeleteAsync(1);
            var actualCount = service.GetDiscussionsCount("All");

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void GetDiscussionsCountShouldReturnAllDiscussionsCountInDb()
        {
            var service = this.GetService(this.GetForumRepository());

            var actualCount = service.GetDiscussionsCount("All");

            Assert.Equal(4, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenDiscussionId()
        {
            var service = this.GetService(this.GetForumRepository());

            var actualDiscussion = service.GetById<DicussionDto>(3);

            Assert.Equal("Test3", actualDiscussion.Title);
        }

        [Fact]
        public void GetAllShouldReturnAllDiscussionsInDb()
        {
            var service = this.GetService(this.GetForumRepository());

            var actualDuscussions = service.GetAllForumDiscussions<DicussionDto>(1, 5, "All");

            Assert.Equal(4, actualDuscussions.Count());
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = this.GetService(this.GetForumRepository());

            var actualUserId = service.GetCreatorId(3);

            Assert.Equal("37699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        [Fact]
        public void GetCategoriesShouldReturnListWithAllCategoriesInDb()
        {
            var service = this.GetService(null, this.GetAdTypesRepository());

            var actualTypes = service.GetCategories<DiscussionTypesModel>();

            Assert.Equal(3, actualTypes.Count());
        }

        [Fact]
        public async Task SetDiscusionToSolvedShouldChangeTheDiscussionStatusInTheDbToTrue()
        {
            var repository = this.GetForumRepository();
            var service = this.GetService(repository);

            await service.SetDiscussionToSolvedAsync(1);
            var result = service.GetById<DicussionDto>(1);

            Assert.True(result.IsSolved);
        }

        private IForumsService GetService(
            IDeletableEntityRepository<Discussion> forumRepository = null,
            IDeletableEntityRepository<Category> categoriesRepository = null)
        {
            var service = new ForumsService(forumRepository, categoriesRepository);

            return service;
        }

        private EfDeletableEntityRepository<Discussion> GetForumRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Discussion>(dbContext);

            return repository;
        }

        private EfDeletableEntityRepository<Category> GetAdTypesRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Category>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            data.Discussions.Add(new Discussion()
            {
                Id = 1,
                Title = "Test1",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 1,
                IsSolved = false,
            });
            data.Discussions.Add(new Discussion()
            {
                Id = 2,
                Title = "Test2",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 3,
                IsSolved = false,
            });
            data.Discussions.Add(new Discussion()
            {
                Id = 3,
                Title = "Test3",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "37699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 1,
                IsSolved = false,
            });
            data.Discussions.Add(new Discussion()
            {
                Id = 4,
                Title = "Test4",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
                CategoryId = 1,
                IsSolved = false,
            });

            data.Categories.Add(new Category()
            {
                Id = 1,
                Name = "News",
            });

            data.Categories.Add(new Category()
            {
                Id = 2,
                Name = "Education",
            });

            data.Categories.Add(new Category()
            {
                Id = 3,
                Name = "Software",
            });

            await data.SaveChangesAsync();

            return data;
        }

        private DiscussionInputModel GetInputModel()
        {
            return new DiscussionInputModel()
            {
                CategoryId = 3,
                Title = "Input",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
            };
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        public class DicussionDto : IMapFrom<Discussion>
        {
            public string Title { get; set; }

            public string Description { get; set; }

            public bool IsSolved { get; set; }

            public int CategoryId { get; set; }

            public string UserId { get; set; }
        }

        public class DiscussionInputModel : IMapTo<Discussion>
        {
            public int CategoryId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }
        }

        public class DiscussionTypesModel : IMapFrom<Category>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
