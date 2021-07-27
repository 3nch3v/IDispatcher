namespace Dispatcher.Data.Models.JobModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Data;
    using static Dispatcher.Common.GlobalConstants.Job;

    public class Job : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(BodyMaxLength)]
        public string JobBody { get; set; }

        [Required]
        [MaxLength(CompanyMaxLength)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; }

        [Required]
        [MaxLength(ContactMaxLength)]
        public string Contact { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string LogoUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
