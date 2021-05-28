namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Job : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(50000, MinimumLength = 100)]
        public string JobBody { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Location { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 6)]
        public string Contact { get; set; }

        [MaxLength(2048)]
        public string LogoUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
