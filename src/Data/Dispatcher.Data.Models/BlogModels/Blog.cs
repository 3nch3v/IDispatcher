namespace Dispatcher.Data.Models.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Blog : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100000)]
        public string Body { get; set; }

        [MaxLength(2048)]
        public string PictureUrl { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
