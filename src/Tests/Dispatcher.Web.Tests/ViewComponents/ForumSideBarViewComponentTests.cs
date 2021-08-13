namespace Dispatcher.Web.Tests.ViewComponents
{
    using Dispatcher.Web.ViewComponents;
    using Dispatcher.Web.ViewModels.ForumModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ForumSideBarViewComponentTests
    {
        [Fact]
        public void ForumSideBarViewComponentShouldReturnView()
            => MyViewComponent<ForumSideBarViewComponent>
                .Instance()
                .InvokedWith(v => v.Invoke())
                .ShouldReturn()
                .View(v => v.WithModelOfType<CategoriesWithDiscussionsCountViewModel>());
    }
}
