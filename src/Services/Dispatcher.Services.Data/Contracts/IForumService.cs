namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;

    public interface IForumService
    {
        Task CreateAsync<T>(T input, string id);

        Task AddCommentAsync<T>(T input);

        Task DeleteAsync(int id);

        Task SetToSolved(int id);

        Task Edit(DiscussionInputModel input, int id);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category);

        IEnumerable<T> GetUnsolvedDiscussions<T>(int page, int pageEntitiesCount);

        int ForumDiscussionsCount();

        int ForumDiscussionsPerCategoryCount();

        int GetUnsolvedCount();

        T GetDiscussion<T>(int id);

        Task DeleteCommentAsync(int id);

        SingleForumDiscussionsViewModel GetDiscussion(int id);
    }
}
