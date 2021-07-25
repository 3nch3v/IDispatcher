namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService : IBaseService
    {
        int GetDiscussionsCount(string category);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category);

        Task SetDiscussionToSolvedAsync(int id);
    }
}
