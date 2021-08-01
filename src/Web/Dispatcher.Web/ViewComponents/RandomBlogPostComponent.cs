namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class RandomBlogPostComponent : ViewComponent
    {
        private readonly IBlogsService blogService;

        public RandomBlogPostComponent(IBlogsService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(bool isWithPicture)
        {
            var blogPost = this.blogService.RandomBlog<SingleRandomBlogPostModel>();
            blogPost.IsWithPicture = isWithPicture;
            return this.View(blogPost);
        }
    }
}
