namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService
    {
        Task CreateAsync<T>(T input, string id);

        IEnumerable<T> GetCategories<T>();

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category);

        int ForumDiscussionsCount();

        int ForumDiscussionsPerCategoryCount();

        T GetDiscussion<T>(int id);

        Task AddCommentAsync<T>(T input);
    }
}
