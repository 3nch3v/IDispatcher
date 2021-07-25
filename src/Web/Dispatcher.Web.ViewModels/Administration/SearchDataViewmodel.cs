namespace Dispatcher.Web.ViewModels.Administration
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class SearchDataViewmodel : IMapFrom<AdminRequestDataDto>
    {
        public IEnumerable<DataViewModel> Data { get; set; }

        public string DataType { get; set; }
    }
}
