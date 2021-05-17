namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService
    {
        Task CreateAsync<T>(T input, string id);

        IEnumerable<T> GetCategories<T>();
    }
}
