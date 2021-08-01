namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Xunit;

    public class ProjectsServiceTests
    {
        public ProjectsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ProjectDto).Assembly, typeof(Project).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewProjectInDb()
        {
            var repository = this.GetBlogsRepository();
            var service = this.GetService(repository);
            var newBlog = this.GetInputModel();

            await service.CreateAsync<ProjectInputModel>(newBlog, this.GetUserId());
            var actualCount = repository.All().Count();

            Assert.Equal(5, actualCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeTheProjectName()
        {
            var service = this.GetService(this.GetBlogsRepository());
            var updateModel = this.GetInputModel();

            await service.UpdateAsync<ProjectInputModel>(updateModel, 2);
            var actualResult = service.GetById<ProjectDto>(2);

            Assert.Equal("Input", actualResult.Name);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var repository = this.GetBlogsRepository();
            var service = this.GetService(repository);

            await service.DeleteAsync(1);
            var actualCount = repository.All().Count();

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenProjectId()
        {
            var service = this.GetService(this.GetBlogsRepository());

            var actualAd = service.GetById<ProjectDto>(3);

            Assert.Equal("Test3", actualAd.Name);
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = this.GetService(this.GetBlogsRepository());

            var actualUserId = service.GetCreatorId(4);

            Assert.Equal("17699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        private IProjectsService GetService(IDeletableEntityRepository<Project> projectRepository)
        {
            var service = new ProjectsService(projectRepository);

            return service;
        }

        private EfDeletableEntityRepository<Project> GetBlogsRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Project>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            await data.Projects.AddAsync(
                new Project
                {
                    Id = 1,
                    Name = "Test1",
                    Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                    UserRole = "Teacher",
                    UserId = this.GetUserId(),
                });
            await data.Projects.AddAsync(
               new Project
               {
                   Id = 2,
                   Name = "Test2",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "Boss",
                   UserId = this.GetUserId(),
               });
            await data.Projects.AddAsync(
               new Project
               {
                   Id = 3,
                   Name = "Test3",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "President",
                   UserId = this.GetUserId(),
               });
            await data.Projects.AddAsync(
               new Project
               {
                   Id = 4,
                   Name = "Test4",
                   Description = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   Url = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                   UserRole = "Taxi Driver",
                   UserId = "1" + this.GetUserId(),
               });

            await data.SaveChangesAsync();

            return data;
        }

        private ProjectInputModel GetInputModel()
        {
            return new ProjectInputModel()
            {
                Name = "Input",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                UserRole = "Hamalin",
            };
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        public class ProjectDto : IMapFrom<Project>
        {
            public string Name { get; set; }

            public string Url { get; set; }

            public string UserRole { get; set; }

            public string Description { get; set; }

            public string UserId { get; set; }
        }

        public class ProjectInputModel : IMapTo<Project>
        {
            public string Name { get; set; }

            public string Url { get; set; }

            public string UserRole { get; set; }

            public string Description { get; set; }
        }
    }
}
