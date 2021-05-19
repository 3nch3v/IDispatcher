﻿namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }
    }
}