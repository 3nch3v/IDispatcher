namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobService
    {
        T GetJob<T>(int id);

        IEnumerable<T> GetAllAsync<T>();

        Task CreateAsync();

        Task DeleteAsync(int id);

        Task EditAsync();
    }
}
