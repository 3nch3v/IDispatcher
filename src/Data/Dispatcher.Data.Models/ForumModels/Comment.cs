namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Discussion))]
        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string Content { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
