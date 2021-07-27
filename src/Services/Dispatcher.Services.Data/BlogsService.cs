namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Attributes;

    public class BlogsService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;
        private readonly IDeletableEntityRepository<BlogImage> blogImagesRepository;

        public BlogsService(
            IDeletableEntityRepository<Blog> blogsRepository,
            IDeletableEntityRepository<BlogImage> blogImagesRepository)
        {
            this.blogsRepository = blogsRepository;
            this.blogImagesRepository = blogImagesRepository;
        }

        public async Task CreateAsync<T>(T input, string userId, string pictureDirectory)
        {
            var blogDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);
            var blog = AutoMapperConfig.MapperInstance.Map<Blog>(input);
            blog.UserId = userId;

            if (!string.IsNullOrEmpty(blog.VideoLink))
            {
                var groups = Regex.Match(blog.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;
                blog.YouTubeVideoId = videoId;
            }

            if (blogDto.Picture != null)
            {
                await this.FileSaverAsync(blog, blogDto, pictureDirectory);
            }

            await this.blogsRepository.AddAsync(blog);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id, string pictureDirectory)
        {
            var blogDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);

            var blog = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            if (!string.IsNullOrEmpty(blogDto.VideoLink) && blogDto.VideoLink != blog.VideoLink)
            {
                var groups = Regex.Match(blogDto.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;
                blog.YouTubeVideoId = videoId;
                blog.VideoLink = blogDto.VideoLink;
            }

            if (blogDto.Title != blog.Title)
            {
                blog.Title = blogDto.Title;
            }

            if (blogDto.Body != blog.Body)
            {
                blog.Body = blogDto.Body;
            }

            blog.ModifiedOn = DateTime.UtcNow;

            if (blogDto.Picture != null)
            {
                await this.FileSaverAsync(blog, blogDto, pictureDirectory);
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

        public T RandomBlogPost<T>()
        {
            var blog = this.blogsRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .To<T>()
                .FirstOrDefault();

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

            return blog.UserId;
        }

        private async Task FileSaverAsync(Blog blog, BlogPostDto input, string pictureDirectory)
        {
            bool isInitialInstance = false;

            var picture = this.blogImagesRepository.All().FirstOrDefault(i => i.BlogId == blog.Id);

            string physicalFilePath = $"{pictureDirectory}/";

            if (picture != null)
            {
                physicalFilePath += $"{picture.Id}{picture.Extension}";

                FileInfo file = new FileInfo(physicalFilePath);

                if (file.Exists)
                {
                    file.Delete();
                }
            }
            else if (picture == null)
            {
                picture = new BlogImage
                {
                    BlogId = blog.Id,
                };

                isInitialInstance = true;
            }

            string newExtension = Path.GetExtension(input.Picture.FileName);
            picture.Extension = newExtension;

            physicalFilePath = $"{pictureDirectory}/{picture.Id}{newExtension}";

            using var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);

            if (isInitialInstance)
            {
                await this.blogImagesRepository.AddAsync(picture);
            }

            await this.blogImagesRepository.SaveChangesAsync();
        }
    }
}
