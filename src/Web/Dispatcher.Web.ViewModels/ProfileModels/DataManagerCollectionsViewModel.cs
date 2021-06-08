namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class DataManagerCollectionsViewModel : IMapFrom<Job>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
