namespace Dispatcher.Web.ViewModels.AdModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class SingleAdViewModel : IMapFrom<Advertisement>
    {
        public int Id { get; set; }

        public int AdvertisementTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Compensation { get; set; }

        public string PictureUrl { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public string UserId { get; set; }
    }
}
