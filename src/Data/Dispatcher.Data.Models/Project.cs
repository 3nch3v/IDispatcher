﻿namespace Dispatcher.Data.Models
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
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
