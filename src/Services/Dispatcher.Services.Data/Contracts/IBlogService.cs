namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IBlogService : IBaseService
    {
        IEnumerable<T> GetAllBlogPosts<T>(int page, int pageEntitiesCount);

        T RandomBlogPost<T>();

        int BlogPostsCount();
    }
}
