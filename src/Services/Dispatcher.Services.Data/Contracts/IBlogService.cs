namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.BlogModels;

    public interface IBlogService
    {
        Task CreatPostAsync(BlogInputModel input, string userId, string pictureDirectory);

        Task UpdatePostAsync(int id, EditBlogPostInputmodel input, string pictureDirectory);

        Task DeleteAsync(int id);

        T GetById<T>(int id);

        IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount);

        T RandomBlogPost<T>();

        int BlogPostsCount();
    }
}
