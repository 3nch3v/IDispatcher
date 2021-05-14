namespace Dispatcher.Web.ViewModels.JobModels
{
    using System.ComponentModel.DataAnnotations;

    public class BaseJobInputModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50000)]
        [MinLength(100)]
        public string JobBody { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Location { get; set; }

        [Required]
        [MaxLength(250)]
        [MinLength(6)]
        public string Contact { get; set; }

        [MaxLength(2048)]
        public string LogoUrl { get; set; }
    }
}
