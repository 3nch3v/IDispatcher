namespace Dispatcher.Web.ViewModels.JobModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.CustomAttributes;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Data;
    using static Dispatcher.Common.GlobalConstants.Job;

    public class JobInputModel : IMapTo<Job>
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(BodyMaxLength, MinimumLength = BodyMinLength)]
        [Display(Name = "Jod Description")]
        public string JobBody { get; set; }

        [Required]
        [StringLength(CompanyMaxLength, MinimumLength = CompanyMinLength)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; }

        [Required]
        [StringLength(ContactMaxLength, MinimumLength = ContactMinLength)]
        public string Contact { get; set; }

        [MaxLength(UrlMaxLenght)]
        [UrlAllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
        public string LogoUrl { get; set; }
    }
}
