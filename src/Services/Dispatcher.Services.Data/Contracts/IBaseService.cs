namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IBaseService
    {
        string GetCreatorId(int dataId);

        T GetById<T>(int id);

        Task CreateAsync<T>(T input, string id);

        Task DeleteAsync(int id);

        Task UpdateAsync<T>(T input, int id);
    }
}
