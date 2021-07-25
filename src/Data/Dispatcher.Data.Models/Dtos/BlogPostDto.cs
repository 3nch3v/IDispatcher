namespace Dispatcher.Data.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.CustomAttributes;
    using Microsoft.AspNetCore.Http;

    using static Dispatcher.Common.GlobalConstants.Attributes;

    public class BlogPostDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 100)]
        public string Body { get; set; }

        [MaxLength(2048)]
        [RegularExpression(YouTubeRegexPattern, ErrorMessage = "Please enter valid YouTube embed code!")]
        public string VideoLink { get; set; }

        [MaxLength(2048)]
        public string PictureDirectory { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [FileAllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
        public IFormFile Picture { get; set; }
    }
}
