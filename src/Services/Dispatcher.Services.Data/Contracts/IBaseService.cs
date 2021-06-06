namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IBaseService
    {
        Task CreateAsync<T>(T input, string id);

        Task DeleteAsync(int id);

        Task UpdateAsync<T>(T input, int id);

        T GetById<T>(int id);
    }
}
