namespace Dispatcher.Web.ViewModels.AdModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.CustomAttributes;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Advertisement;
    using static Dispatcher.Common.GlobalConstants.Data;

    public class AdInputModel : IMapTo<Advertisement>
    {
        [Range(TypeMinRange, TypeMaxRange, ErrorMessage = InvalidType)]
        public int AdvertisementTypeId { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(CompensationMaxLenght)]
        public string Compensation { get; set; }

        [MaxLength(UrlMaxLenght)]
        [UrlAllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
        public string PictureUrl { get; set; }

        public IEnumerable<AdTypesViewModel> AdTypes { get; set; }
    }
}
