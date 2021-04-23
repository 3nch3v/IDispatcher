namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Discussion : BaseDeletableModel<int>
    {
        public Discussion()
        {
            this.UserDiscussions = new HashSet<UserDiscussion>();
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        public virtual ICollection<UserDiscussion> UserDiscussions { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
