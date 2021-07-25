namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IAdsService : IBaseService
    {
        int AdsCount();

        int SearchCount();

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string searchParams);

        IEnumerable<T> GetAllAds<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetAllAdTypes<T>();

        IEnumerable<T> RandomAds<T>(int adsCount);
    }
}
