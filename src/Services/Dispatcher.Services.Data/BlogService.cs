namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.BlogModels;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogsRepository;

        public BlogService(IDeletableEntityRepository<Blog> blogsRepository)
        {
            this.blogsRepository = blogsRepository;
        }

        public async Task CreatPostAsync(BlogInputModel inputModel, string id)
        {
            Blog post = new Blog
            {
                Title = inputModel.Title,
                Body = inputModel.Body,
                RemotePictureUrl = inputModel.RemotePictureUrl,
                UserId = id,
            };

            await this.blogsRepository.AddAsync(post);
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
    }
}
