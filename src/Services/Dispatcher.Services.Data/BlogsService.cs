namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Microsoft.Extensions.Caching.Memory;

    using static Dispatcher.Common.GlobalConstants.Attributes;

    public class BlogsService : IBlogsService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;
        private readonly IDeletableEntityRepository<BlogImage> blogImagesRepository;
        private readonly IFilesService filesService;
        private readonly IMemoryCache memoryCache;

        public BlogsService(
            IDeletableEntityRepository<Blog> blogsRepository,
            IDeletableEntityRepository<BlogImage> blogImagesRepository,
            IFilesService filesService,
            IMemoryCache memoryCache)
        {
            this.blogsRepository = blogsRepository;
            this.blogImagesRepository = blogImagesRepository;
            this.filesService = filesService;
            this.memoryCache = memoryCache;
        }

        public async Task CreateAsync<T>(T input, string userId, byte[] picture, string picturePath, string pictureExtension)
        {
            var blog = AutoMapperConfig.MapperInstance.Map<Blog>(input);

            blog.UserId = userId;

            if (!string.IsNullOrEmpty(blog.VideoLink))
            {
                var groups = Regex.Match(blog.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;

                blog.YouTubeVideoId = videoId;
            }

            if (picture != null)
            {
                var image = await this.CreateImageAsync(blog, picture, picturePath, pictureExtension);

                blog.BlogImage = image;
            }

            await this.blogsRepository.AddAsync(blog);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id, byte[] picture, string picturePath, string pictureExtension)
        {
            var blogDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);

            var blog = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            if (blogDto.Title != blog.Title)
            {
                blog.Title = blogDto.Title;
            }

            if (blogDto.Body != blog.Body)
            {
                blog.Body = blogDto.Body;
            }

            if (!string.IsNullOrEmpty(blogDto.VideoLink) && blogDto.VideoLink != blog.VideoLink)
            {
                var groups = Regex.Match(blogDto.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;

                blog.YouTubeVideoId = videoId;
                blog.VideoLink = blogDto.VideoLink;
            }
            else
            {
                blog.YouTubeVideoId = default;
                blog.VideoLink = default;
            }

            if (blogDto.Picture != null)
            {
                var image = await this.CreateImageAsync(blog, picture, picturePath, pictureExtension);

                blog.BlogImage = image;
            }

            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blog = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            this.blogsRepository.Delete(blog);
            await this.blogsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount)
        {
            var blog = this.blogsRepository
                .All()
                .OrderByDescending(j => j.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return blog;
        }

        public T GetById<T>(int id)
        {
            var blog = this.blogsRepository.AllAsNoTracking()
                .Where(b => b.Id == id)
                .To<T>()
                .FirstOrDefault();

            return blog;
        }

        public T RandomBlog<T>()
        {
            var blog = this.memoryCache
                .GetOrCreate("RandomBlog", entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromSeconds(7);
                    return this.blogsRepository.AllAsNoTracking()
                            .OrderBy(x => Guid.NewGuid())
                            .To<T>()
                            .FirstOrDefault();
                });

            return blog;
        }

        public int BlogPostsCount()
        {
            return this.blogsRepository.AllAsNoTracking().Count();
        }

        public string GetCreatorId(int id)
        {
            var blog = this.blogsRepository.AllAsNoTracking()
                .Where(b => b.Id == id)
                .FirstOrDefault();

            return blog?.UserId;
        }

        private async Task<BlogImage> CreateImageAsync(Blog blog, byte[] picture, string picturePath, string pictureExtension)
        {
            var pictureData = this.blogImagesRepository.All().FirstOrDefault(i => i.BlogId == blog.Id);

            if (pictureData != null)
            {
                this.filesService.DeleteFile(picturePath, pictureData.Id, pictureData.Extension);
            }
            else
            {
                pictureData = new BlogImage();
            }

            pictureData.Extension = pictureExtension;

            await this.filesService.SaveFileAsync(picture, picturePath, pictureData.Id, pictureExtension);

            return pictureData;
        }
    }
}
