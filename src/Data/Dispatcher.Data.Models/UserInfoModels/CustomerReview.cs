namespace Dispatcher.Data.Models.UserInfoModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class CustomerReview : BaseDeletableModel<int>
    {
        public int StarsCount { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
