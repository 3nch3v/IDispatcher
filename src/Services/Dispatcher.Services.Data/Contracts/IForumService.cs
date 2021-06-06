namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;

    public interface IForumService : IBaseService
    {
        Task SetDiscussionToSolvedAsync(int id);

        SingleForumDiscussionsViewModel GetDiscussion(int id);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<SingleForumDiscussionsViewModel> GetAllForumDiscussions(int page, int pageEntitiesCount, string category);

        int ForumDiscussionsCount();

        int GetDiscussionsCountPerCategory(string category);

        int GetUnsolvedDiscussionsCount();
    }
}
