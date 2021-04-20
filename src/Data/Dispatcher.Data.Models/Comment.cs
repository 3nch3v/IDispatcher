namespace Dispatcher.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int АdvertisementId { get; set; }

        public virtual Аdvertisement Аdvertisement { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public int Like { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
