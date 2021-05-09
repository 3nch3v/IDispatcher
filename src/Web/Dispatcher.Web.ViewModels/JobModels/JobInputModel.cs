namespace Dispatcher.Web.ViewModels.JobModels
{
    using System.ComponentModel.DataAnnotations;

    public class JobInputModel
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50000)]
        public string JobBody { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MaxLength(250)]
        public string Contact { get; set; }

        [MaxLength(2048)]
        public string LogoUrl { get; set; }
    }
}
