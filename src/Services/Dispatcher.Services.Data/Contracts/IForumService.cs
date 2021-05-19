namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;

    public interface IForumService
    {
        Task CreateAsync<T>(T input, string id);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category);

        int ForumDiscussionsCount();

        int ForumDiscussionsPerCategoryCount();

        SingleForumDiscussionsViewModel GetDiscussion(int id);

        Task AddCommentAsync<T>(T input);
    }
}
