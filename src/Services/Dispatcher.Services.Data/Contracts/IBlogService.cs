namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;

    public interface IBlogService
    {
        Task CreateAsync<T>(T input, string id, string pictureDirectory);

        Task DeleteAsync(int id);

        Task UpdateAsync<T>(T input, int id, string pictureDirectory);

        string GetCreatorId(int dataId);

        int BlogPostsCount();

        T GetById<T>(int id);

        T RandomBlog<T>();

        IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount);
    }
}
