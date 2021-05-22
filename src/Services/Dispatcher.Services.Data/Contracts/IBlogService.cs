namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.BlogModels;

    public interface IBlogService
    {
        T GetPost<T>(int id);

        IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount);

        Task CreatPostAsync(BlogInputModel inputModel, string userId, string imgPath);

        Task UpdatePostAsync(int id, EditBlogPostInputmodel input);

        Task DeleteAsync(int id);

        T RandomBlogPost<T>();

        int BlogPostsCount();
    }
}
