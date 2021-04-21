namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Advertisement : BaseDeletableModel<int>
    {
        public Advertisement()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int AdvertisementTypeId { get; set; }

        public virtual AdvertisementType AdvertisementType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Compensation { get; set; }

        public int Like { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
