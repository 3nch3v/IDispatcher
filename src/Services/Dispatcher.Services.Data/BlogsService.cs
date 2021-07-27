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
            var blogPostDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);

            var post = AutoMapperConfig.MapperInstance.Map<Blog>(input);
            post.UserId = userId;

            if (!string.IsNullOrEmpty(post.VideoLink))
            {
                var groups = Regex.Match(post.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;
                post.YouTubeVideoId = videoId;
            }

            if (blogPostDto.Picture != null)
            {
                await this.FileSaverAsync(post, blogPostDto, pictureDirectory);
            }

            await this.blogsRepository.AddAsync(post);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id, string pictureDirectory)
        {
            var blogPostDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);

            var post = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            if (!string.IsNullOrEmpty(blogPostDto.VideoLink) && blogPostDto.VideoLink != post.VideoLink)
            {
                var groups = Regex.Match(blogPostDto.VideoLink, YouTubeRegexPattern).Groups;
                var videoId = groups["VideoId"].Value;
                post.YouTubeVideoId = videoId;
            }

            if (blogPostDto.Title != post.Title)
            {
                post.Title = blogPostDto.Title;
            }

            if (blogPostDto.Body != post.Body)
            {
                post.Body = blogPostDto.Body;
            }

            post.ModifiedOn = DateTime.UtcNow;

            if (blogPostDto.Picture != null)
            {
                await this.FileSaverAsync(post, blogPostDto, pictureDirectory);
            }

            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletePost = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            this.blogsRepository.Delete(deletePost);
            await this.blogsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount)
        {

            var posts1 = this.blogsRepository.All().FirstOrDefault();

            var posts = this.blogsRepository
                .All()
                .OrderByDescending(j => j.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return posts;
        }

        public T GetById<T>(int id)
        {
            var post = this.blogsRepository.AllAsNoTracking()
                .Where(b => b.Id == id)
                .To<T>()
                .FirstOrDefault();

            return post;
        }

        public T RandomBlogPost<T>()
        {
            var blogPost = this.blogsRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .To<T>()
                .FirstOrDefault();

            return blogPost;
        }

        public int BlogPostsCount()
        {
            return this.blogsRepository.AllAsNoTracking().Count();
        }

        public string GetCreatorId(int id)
        {
            var post = this.blogsRepository.AllAsNoTracking()
                .Where(b => b.Id == id)
                .FirstOrDefault();

            return post.UserId;
        }

        private async Task FileSaverAsync(Blog post, BlogPostDto input, string pictureDirectory)
        {
            string fileExtension = Path.GetExtension(input.Picture.FileName);

            var image = new BlogImage
            {
                Extension = fileExtension,
                BlogId = post.Id,
            };

            string physicalFilePath = $"{pictureDirectory}/{image.Id}{fileExtension}";

            using var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);

            await this.blogImagesRepository.AddAsync(image);
            await this.blogImagesRepository.SaveChangesAsync();
        }
    }
}
