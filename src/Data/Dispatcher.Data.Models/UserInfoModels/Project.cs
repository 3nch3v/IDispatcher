namespace Dispatcher.Data.Models.UserInfoModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Url { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserRole { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
