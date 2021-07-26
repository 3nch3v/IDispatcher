namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class CommentVote : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }
    }
}
