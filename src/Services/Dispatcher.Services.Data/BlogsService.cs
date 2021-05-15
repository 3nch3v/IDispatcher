namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.BlogModels;

    public class BlogsService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogsRepository)
        {
            this.blogsRepository = blogsRepository;
        }

        public async Task CreatPostAsync(BlogInputModel inputModel, string userId)
        {
            Blog post = AutoMapperConfig.MapperInstance.Map<Blog>(inputModel);
            post.UserId = userId;
            await this.blogsRepository.AddAsync(post);
            await this.blogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletePost = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);
            this.blogsRepository.Delete(deletePost);
            await this.blogsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBlogPosts<T>()
        {
            var posts = this.blogsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return posts;
        }

        public T GetPost<T>(int id)
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

        public async Task UpdatePostAsync(int id, EditBlogPostInputmodel input)
        {
            var post = this.blogsRepository.All().FirstOrDefault(p => p.Id == id);
            post.Title = input.Title;
            post.Body = input.Body;
            post.RemotePictureUrl = input.RemotePictureUrl;
            post.ModifiedOn = DateTime.UtcNow;

            await this.blogsRepository.SaveChangesAsync();
        }
    }
}
