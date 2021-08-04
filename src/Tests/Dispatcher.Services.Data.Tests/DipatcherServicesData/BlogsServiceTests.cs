namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Caching.Memory;
    using Xunit;

    using static Dispatcher.Common.GlobalConstants.Blog;

    public class BlogsServiceTests
    {
        public BlogsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(BlogInputModel).Assembly, typeof(BlogPostDto).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(BlogInputModel).Assembly, typeof(Blog).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(BlogDto).Assembly, typeof(Blog).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewBlogInDb()
        {
            var service = GetService(GetBlogsRepository());
            var newBlog = GetInputModel();

            await service.CreateAsync<BlogInputModel>(newBlog, GetUserId(), null, BlogPicturePath, null);
            var actualCount = service.BlogPostsCount();

            Assert.Equal(5, actualCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeBlogInDb()
        {
            var service = GetService(GetBlogsRepository());
            var updateModel = GetInputModel();

            await service.UpdateAsync<BlogInputModel>(updateModel, 1, null, BlogPicturePath, null);
            var actualResult = service.GetById<BlogDto>(1);

            Assert.Equal("Input", actualResult.Title);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var service = GetService(GetBlogsRepository());

            await service.DeleteAsync(1);
            var actualCount = service.BlogPostsCount();

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void BlogPostsCountShouldReturnAllBlogsCountInDb()
        {
            var service = GetService(GetBlogsRepository());

            var actualCount = service.BlogPostsCount();

            Assert.Equal(4, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenBlogId()
        {
            var service = GetService(GetBlogsRepository());

            var actualAd = service.GetById<BlogDto>(3);

            Assert.Equal("Test3", actualAd.Title);
        }

        [Fact]
        public void GetAllShouldReturnAllBlogsInDb()
        {
            var service = GetService(GetBlogsRepository());

            var actualAds = service.GetAllBlogPosts<BlogDto>(1, 5);

            Assert.Equal(4, actualAds.Count());
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = GetService(GetBlogsRepository());

            var actualUserId = service.GetCreatorId(2);

            Assert.Equal("17699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        private static async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            await data.Blogs.AddAsync(
                new Blog
                {
                    Id = 1,
                    Title = "Test1",
                    Body = "1 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                    VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s1",
                    UserId = GetUserId(),
                });
            await data.Blogs.AddAsync(
               new Blog
               {
                   Id = 2,
                   Title = "Test2",
                   Body = "2 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s2",
                   UserId = "1" + GetUserId(),
               });
            await data.Blogs.AddAsync(
               new Blog
               {
                   Id = 3,
                   Title = "Test3",
                   Body = "3 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s3",
                   UserId = GetUserId(),
               });
            await data.Blogs.AddAsync(
               new Blog
               {
                   Id = 4,
                   Title = "Test4",
                   Body = "4 We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                   VideoLink = "https://www.youtube.com/watch?v=9OD8i1PUyT8&t=2375s4",
                   UserId = GetUserId(),
               });

            await data.SaveChangesAsync();

            return data;
        }

        private static IBlogsService GetService(
            IDeletableEntityRepository<Blog> blogsRepository = null,
            IDeletableEntityRepository<BlogImage> blogImagesRepository = null,
            IFilesService filesService = null,
            IMemoryCache memoryCache = null)
        {
            var service = new BlogsService(blogsRepository, blogImagesRepository, filesService, memoryCache);

            return service;
        }

        private static string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        private static EfDeletableEntityRepository<Blog> GetBlogsRepository()
        {
            var dbContext = PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Blog>(dbContext);

            return repository;
        }

        private static BlogInputModel GetInputModel()
        {
            return new BlogInputModel()
            {
                Title = "Input",
                Body = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
            };
        }

        public class BlogDto : IMapFrom<Blog>
        {
            public string Title { get; set; }

            public string Body { get; set; }

            public string VideoLink { get; set; }

            public string YouTubeVideoId { get; set; }

            public string BlogImageId { get; set; }

            public string UserId { get; set; }
        }

        public class BlogInputModel : IMapTo<Blog>, IMapTo<BlogPostDto>
        {
            public string Title { get; set; }

            public string Body { get; set; }

            public string VideoLink { get; set; }

            public IFormFile Picture { get; set; }
        }
    }
}
