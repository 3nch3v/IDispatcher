﻿namespace Dispatcher.Data.Models.AdvertisementModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class Job : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(5000)]
        public string JobBody { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(250)]
        public string Contact { get; set; }

        [MaxLength(2048)]
        public string LogoUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}