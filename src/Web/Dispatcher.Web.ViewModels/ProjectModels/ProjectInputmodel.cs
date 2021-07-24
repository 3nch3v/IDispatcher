namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProjectInputmodel : IMapTo<Project>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Url { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserRole { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
    }
}
