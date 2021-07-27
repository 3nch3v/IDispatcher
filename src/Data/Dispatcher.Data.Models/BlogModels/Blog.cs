namespace Dispatcher.Data.Models.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.Blog;
    using static Dispatcher.Common.GlobalConstants.Data;

    public class Blog : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(BodyMaxLength)]
        public string Body { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string VideoLink { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string YouTubeVideoId { get; set; }

        public string BlogImageId { get; set; }

        public virtual BlogImage BlogImage { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
