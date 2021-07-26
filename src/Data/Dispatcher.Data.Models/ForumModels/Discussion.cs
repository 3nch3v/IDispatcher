namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class Discussion : BaseDeletableModel<int>
    {
        public Discussion()
        {
            this.Posts = new HashSet<Comment>();
            this.Votes = new HashSet<DiscussionVote>();
        }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMAxLenght)]
        public string Description { get; set; }

        public bool IsSolved { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Posts { get; set; }

        public virtual ICollection<DiscussionVote> Votes { get; set; }
    }
}
