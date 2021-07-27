namespace Dispatcher.Data.Models.UserInfoModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Data;
    using static Dispatcher.Common.GlobalConstants.Project;

    public class Project : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string Url { get; set; }

        [Required]
        [MaxLength(RoleMaxLenght)]
        public string UserRole { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
