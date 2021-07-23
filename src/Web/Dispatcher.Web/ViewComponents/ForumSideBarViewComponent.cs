namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class ForumSideBarViewComponent : ViewComponent
    {
        private readonly IForumService forumServices;

        public ForumSideBarViewComponent(IForumService forumServices)
        {
            this.forumServices = forumServices;
        }

        public IViewComponentResult Invoke()
        {
            var categories = new CategoriesWithDiscussionsCountViewModel
            {
                Categories = this.forumServices.GetCategories<SingleCategoryViewModel>(),
                UnsolvedCount = this.forumServices.GetDiscussionsCount(Unsolved),
            };

            return this.View(categories);
        }
    }
}
