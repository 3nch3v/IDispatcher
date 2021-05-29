namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ForumModels;

    public interface IForumService
    {
        Task CreateAsync<T>(T input, string id);

        Task AddCommentAsync<T>(T input);

        Task DeleteDiscussionAsync(int id);

        Task SetDiscussionToSolvedAsync(int id);

        Task EditDiscussionAsync(DiscussionInputModel input, int id);

        Task DeleteCommentAsync(int id);

        int ForumDiscussionsCount();

        int GetDiscussionsCountPerCategory(string category);

        int GetUnsolvedDiscussionsCount();

        T GetDiscussion<T>(int id);

        IEnumerable<T> GetCategories<T>();

        SingleForumDiscussionsViewModel GetDiscussion(int id);

        IEnumerable<SingleForumDiscussionsViewModel> GetAllForumDiscussions(int page, int pageEntitiesCount, string category);
    }
}
