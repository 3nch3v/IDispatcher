namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Votes = new HashSet<CommentVote>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Discussion))]
        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }

        [Required]
        [MaxLength(CommentMaxLenght)]
        public string Content { get; set; }

        public virtual ICollection<CommentVote> Votes { get; set; }
    }
}
