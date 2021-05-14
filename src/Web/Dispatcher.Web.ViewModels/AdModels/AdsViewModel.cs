namespace Dispatcher.Web.ViewModels.AdModels
{
    using System;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class AdsViewModel : IMapFrom<Advertisement>
    {
        public int Id { get; set; }

        public string AdvertisementTypeType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserUsername { get; set; }

        public string PictureUrl { get; set; }
    }
}
