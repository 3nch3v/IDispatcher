namespace Dispatcher.Web.ViewModels.AdModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class AdInputModel : IMapTo<Advertisement>
    {
        public int AdvertisementTypeId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Compensation { get; set; }

        [MaxLength(2048)]
        public string PictureUrl { get; set; }

        public IEnumerable<AdTypesDropDownViewModel> AdTypes { get; set; }
    }
}
