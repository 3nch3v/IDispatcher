namespace Dispatcher.Web.ViewModels.AdModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class EditAdViewModel : AdInputModel, IMapFrom<Advertisement>
    {
        public int Id { get; set; }
    }
}
