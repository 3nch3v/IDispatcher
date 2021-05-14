namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdsService
    {
        IEnumerable<T> GetAllAds<T>();

        T GetAd<T>(int id);
    }
}
