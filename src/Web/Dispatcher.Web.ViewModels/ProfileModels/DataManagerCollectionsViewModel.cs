namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Services.Mapping;

    public class DataManagerCollectionsViewModel : IMapFrom<Job>, IMapFrom<DataManagerCollectionsDto>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
