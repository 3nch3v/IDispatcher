namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IJobsService : IBaseService
    {
        int JobsCount();

        int SearchCount();

        IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string keyWords);

        IEnumerable<T> GetAll<T>(int page, int pageEntitiesCount);

        IEnumerable<T> GetRandomJobs<T>(int count);
    }
}
