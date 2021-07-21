namespace Dispatcher.Web.ViewModels.Administration
{
    using System.Collections.Generic;

    public class SearchDataViewmodel
    {
        public IEnumerable<DataViewModel> Data { get; set; }

        public string DataType { get; set; }
    }
}
