namespace Dispatcher.Web.ViewModels.AdModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class EditAdViewModel : IMapFrom<Advertisement>
    {
        public int Id { get; set; }

        public int AdvertisementTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Compensation { get; set; }

        public string PictureUrl { get; set; }

        public IEnumerable<AdTypesDropDownViewModel> AdTypes { get; set; }
    }
}
