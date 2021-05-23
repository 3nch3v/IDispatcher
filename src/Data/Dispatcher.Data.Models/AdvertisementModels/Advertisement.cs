namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class Advertisement : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(AdvertisementType))]
        public int AdvertisementTypeId { get; set; }

        public virtual AdvertisementType AdvertisementType { get; set; }

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

        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
