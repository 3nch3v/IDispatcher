namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class BlogInputModel : IMapTo<Blog>
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
