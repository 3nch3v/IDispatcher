namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService : IBaseService
    {
        Task SetDiscussionToSolvedAsync(int id);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category);

        int ForumDiscussionsCount();

        int GetDiscussionsCountPerCategory(string category);

        int GetUnsolvedDiscussionsCount();
    }
}
