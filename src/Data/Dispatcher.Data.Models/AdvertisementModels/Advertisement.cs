namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Advertisement;
    using static Dispatcher.Common.GlobalConstants.File;

    public class Advertisement : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(AdvertisementType))]
        public int AdvertisementTypeId { get; set; }

        public virtual AdvertisementType AdvertisementType { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(CompensationMaxLenght)]
        public string Compensation { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string PictureUrl { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
