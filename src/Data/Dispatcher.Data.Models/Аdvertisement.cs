namespace Dispatcher.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Аdvertisement : BaseDeletableModel<int>
    {
        public Аdvertisement()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string АdvertisementType { get; set; }

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
