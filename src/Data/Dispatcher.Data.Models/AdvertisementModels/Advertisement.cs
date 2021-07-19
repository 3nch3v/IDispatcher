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

        /// <summary>
        /// Gets or sets a value indicating whether remove it, you dont use it.
        /// </summary>
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
