namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IJobService : IBaseService
    {
        int JobsCount();

        int SearchCount();

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string keyWords);

        IEnumerable<T> GetAll<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetRandomJobs<T>(int count);
    }
}
