namespace Dispatcher.Web.ViewModels.AdModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class EditAdvertisementViewModel : AdvertisementInputModel, IMapFrom<Advertisement>
    {
        public int Id { get; set; }
    }
}
