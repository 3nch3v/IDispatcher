namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public int Like { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
