namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class BlogInputModel : BaseBlogPostInputModel, IMapTo<Blog>
    {
        [Required]
        public string UserId { get; set; }
    }
}
