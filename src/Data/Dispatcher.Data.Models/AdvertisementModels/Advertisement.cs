namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class Advertisement : BaseDeletableModel<int>
    {
        public Advertisement()
        {
            this.Comments = new HashSet<Comment>();
        }

        [ForeignKey(nameof(AdvertisementType))]
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

        [MaxLength(2048)]
        public string PictureUrl { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
