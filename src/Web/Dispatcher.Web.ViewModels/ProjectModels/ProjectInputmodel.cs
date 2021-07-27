﻿namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Data;
    using static Dispatcher.Common.GlobalConstants.Project;

    public class ProjectInputmodel : IMapTo<Project>
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string Url { get; set; }

        [Required]
        [StringLength(RoleMaxLenght, MinimumLength = RoleMinLenght)]
        public string UserRole { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; }
    }
}
