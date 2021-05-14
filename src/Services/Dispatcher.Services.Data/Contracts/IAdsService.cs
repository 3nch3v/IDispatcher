namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.AdModels;

    public interface IAdsService
    {
        IEnumerable<T> GetAllAds<T>();

        T GetAd<T>(int id);

        Task CreateAsync(AdInputModel input, string userId);

        IEnumerable<T> GetAllAdTypes<T>();

        Task UpdateAsync(AdInputModel input, int id);

        Task DeleteAsync(int id);
    }
}
