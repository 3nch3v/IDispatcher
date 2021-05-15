﻿namespace Dispatcher.Data.Models.UserInfoModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class CustomerReview : BaseDeletableModel<int>
    {
        public int StarsCount { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Appraiser))]
        public string AppraiserId { get; set; }

        public virtual ApplicationUser Appraiser { get; set; }
    }
}