namespace Dispatcher.Data.Models.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Blog : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 100)]
        public string Body { get; set; }

        [Required]
        [MaxLength(2048)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(2048)]
        public string PhysicalFilePath { get; set; }

        [MaxLength(2048)]
        public string VideoLink { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
