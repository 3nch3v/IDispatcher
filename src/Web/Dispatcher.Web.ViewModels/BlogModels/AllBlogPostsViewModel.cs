namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System.Collections.Generic;

    public class AllBlogPostsViewModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; }
    }
}
