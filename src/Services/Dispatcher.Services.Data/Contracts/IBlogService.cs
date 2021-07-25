namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IBlogService : IBaseService
    {
        int BlogPostsCount();

        T RandomBlogPost<T>();

        IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount);
    }
}
