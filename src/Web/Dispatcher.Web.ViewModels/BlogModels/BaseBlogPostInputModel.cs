namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseBlogPostInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 100)]
        public string Body { get; set; }

        [MaxLength(2048)]
        public string RemotePictureUrl { get; set; }
    }
}
