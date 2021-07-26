namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class DiscussionVote : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }
    }
}
