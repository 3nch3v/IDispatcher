namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProjectInputmodel : IMapTo<Project>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Url { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string UserRole { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
