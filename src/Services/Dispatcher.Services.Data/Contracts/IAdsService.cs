namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.AdModels;

    public interface IAdsService
    {
        IEnumerable<T> GetAllAds<T>(int page, int pageEntitiesCount);

        T GetAd<T>(int id);

        Task CreateAsync(AdInputModel input, string userId);

        IEnumerable<T> GetAllAdTypes<T>();

        Task UpdateAsync(AdInputModel input, int id);

        Task DeleteAsync(int id);

        IEnumerable<T> RandomAds<T>(int adsCount);

        int AdsCount();

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string searchParams);

        int SearchCount();
    }
}
