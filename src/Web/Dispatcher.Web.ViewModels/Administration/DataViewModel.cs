namespace Dispatcher.Web.ViewModels.Administration
{
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class DataViewModel : IMapFrom<SearchDataDto>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }
    }
}
