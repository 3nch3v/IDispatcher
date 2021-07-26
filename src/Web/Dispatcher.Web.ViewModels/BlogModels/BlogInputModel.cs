namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.CustomAttributes;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    using static Dispatcher.Common.GlobalConstants.Attributes;
    using static Dispatcher.Common.GlobalConstants.Blog;
    using static Dispatcher.Common.GlobalConstants.File;

    public class BlogInputModel : IMapTo<Blog>, IMapTo<BlogPostDto>
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(BodyMaxLength, MinimumLength = BodyMinLength)]
        public string Body { get; set; }

        [MaxLength(UrlMaxLenght)]
        [RegularExpression(YouTubeRegexPattern, ErrorMessage = YouTubeError)]
        public string VideoLink { get; set; }

        [MaxFileSize(FileMaxSize)]
        [FileAllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" })]
        public IFormFile Picture { get; set; }
    }
}
