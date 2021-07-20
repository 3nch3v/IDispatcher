namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;

    using Dispatcher.Services.Data.Dtos;

    public interface IAdministartorsServices
    {
        AdminIndexDto GetIndexData();

        IEnumerable<SearchDataDto> GetData(string searchData, string searchMethod, string searchTerm);
    }
}
