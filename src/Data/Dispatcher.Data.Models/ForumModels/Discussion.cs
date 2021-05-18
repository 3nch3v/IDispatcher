namespace Dispatcher.Data.Models.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Discussion : BaseDeletableModel<int>
    {
        public Discussion()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(5000)]
        public string Description { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public bool IsSolved { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
