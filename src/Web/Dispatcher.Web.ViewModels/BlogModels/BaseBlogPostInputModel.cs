namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Common;
    using Dispatcher.Data.Common.CustomAttributes;
    using Microsoft.AspNetCore.Http;

    public abstract class BaseBlogPostInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 100)]
        public string Body { get; set; }

        [MaxLength(2048)]
        public string VideoLink { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
        public IFormFile Picture { get; set; }
    }
}
