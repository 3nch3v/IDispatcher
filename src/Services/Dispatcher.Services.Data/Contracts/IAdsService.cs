namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.AdModels;

    public interface IAdsService
    {
        Task CreateAsync(AdInputModel input, string userId);

        Task UpdateAsync(AdInputModel input, int id);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAllAds<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetAllAdTypes<T>();

        IEnumerable<T> RandomAds<T>(int adsCount);

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string searchParams);

        T GetAd<T>(int id);

        int AdsCount();

        int SearchCount();
    }
}
