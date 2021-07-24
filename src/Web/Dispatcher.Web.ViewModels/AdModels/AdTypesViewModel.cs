namespace Dispatcher.Web.ViewModels.AdModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class AdTypesViewModel : IMapFrom<AdvertisementType>
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
