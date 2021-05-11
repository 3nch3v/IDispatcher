namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdService
    {
        IEnumerable<T> GetAllAds<T>();
    }
}
