namespace Dispatcher.Web.ViewModels.JobModels
{
    using System.ComponentModel.DataAnnotations;

    public class BaseJobInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(50000, MinimumLength = 100)]
        [Display(Name = "Jod Description")]
        public string JobBody { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Location { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 6)]
        public string Contact { get; set; }

        [MaxLength(2048)]
        public string LogoUrl { get; set; }
    }
}
