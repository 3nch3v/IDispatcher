namespace Dispatcher.Web.ViewModels.AdModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class EditAdViewModel : IMapFrom<Advertisement>
    {
        public int Id { get; set; }

        public int AdvertisementTypeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Compensation { get; set; }

        [MaxLength(2048)]
        public string PictureUrl { get; set; }

        public IEnumerable<AdTypesDropDownViewModel> AdTypes { get; set; }
    }
}
