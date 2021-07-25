namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Blog;

    public class BlogsService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogsRepository)
        {
            this.blogsRepository = blogsRepository;
        }

        public async Task CreateAsync<T>(T input, string userId)
        {
            var blogPostDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);
            var post = AutoMapperConfig.MapperInstance.Map<Blog>(input);
            post.UserId = userId;

            if (blogPostDto.Picture != null)
            {
                await this.FileSaverAsync(post, blogPostDto);
            }

            await this.blogsRepository.AddAsync(post);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id)
        {
            var blogPostDto = AutoMapperConfig.MapperInstance.Map<BlogPostDto>(input);

            var post = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);

            post.Title = blogPostDto.Title;
            post.Body = blogPostDto.Body;
            post.VideoLink = blogPostDto.VideoLink;
            post.ModifiedOn = DateTime.UtcNow;

            if (blogPostDto.Picture != null)
            {
                await this.FileSaverAsync(post, blogPostDto);
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
            var posts = this.blogsRepository
                .AllAsNoTracking()
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

        private async Task FileSaverAsync(Blog post, BlogPostDto input)
        {
            string filePath = $"{BlogPicturePath}/{input.Picture.FileName}";
            string physicalFilePath = $"{input.PictureDirectory}/{input.Picture.FileName}";

            post.FilePath = filePath;
            post.PhysicalFilePath = physicalFilePath;

            using var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);
        }
    }
}
