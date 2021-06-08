namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Data.Dtos;
    using Dispatcher.Services.Mapping;

    public class BlogsService : IBlogService
    {
        private const string DefaultBlogPicturesFolder = "/img/blog-pictures";

        private readonly IDeletableEntityRepository<Blog> blogsRepository;
        private readonly IMapper mapper;

        public BlogsService(
            IDeletableEntityRepository<Blog> blogsRepository,
            IMapper mapper)
        {
            this.blogsRepository = blogsRepository;
            this.mapper = mapper;
        }

        public async Task CreateAsync<T>(T input, string userId)
        {
            var blogPostDto = this.mapper.Map<BlogPostDto>(input);
            Blog post = AutoMapperConfig.MapperInstance.Map<Blog>(input);
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
            var blogPostDto = this.mapper.Map<BlogPostDto>(input);

            Blog post = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);
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
            return this.blogsRepository.All().Count();
        }

        private async Task FileSaverAsync(Blog post, BlogPostDto input)
        {
            string filePath = $"{DefaultBlogPicturesFolder}/{input.Picture.FileName}";
            string physicalFilePath = $"{input.PictureDirectory}/{input.Picture.FileName}";

            post.FilePath = filePath;
            post.PhysicalFilePath = physicalFilePath;

            using var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);
        }
    }
}
