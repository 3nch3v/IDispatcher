namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class RandomBlogPostComponent : ViewComponent
    {
        private readonly IBlogService blogService;

        public RandomBlogPostComponent(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blogPost = this.blogService.RandomBlogPost<SingleRandomBlogPostModel>();

            return this.View(blogPost);
        }
    }
}
