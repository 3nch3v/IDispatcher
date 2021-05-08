namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.BlogModels;

    public interface IBlogService
    {
        IEnumerable<T> GetAllBlogPosts<T>();

        Task CreatPostAsync(BlogInputModel inputModel, string id);

        T GetPost<T>(int id);

        Task UpdatePostAsync(int id, EditBlogPostInputmodel input);

        Task DeleteAsync(int id);
    }
}
