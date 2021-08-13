namespace Dispatcher.Web.Tests.ViewComponents
{
    using Dispatcher.Web.ViewComponents;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class RandomBlogPostComponentTests
    {
        [Theory]
        [InlineData(false)]
        public void ForumSideBarViewComponentShouldReturnViewWithOut(bool isWithPicture)
        => MyViewComponent<RandomBlogPostComponent>
            .Instance()
            .WithData(GetBlog())
            .InvokedWith(v => v.Invoke(isWithPicture))
            .ShouldReturn()
            .View(v => v.WithModelOfType<SingleRandomBlogPostModel>(m => m.IsWithPicture
                .ShouldBe(isWithPicture)));

        [Theory]
        [InlineData(true)]
        public void ForumSideBarViewComponentShouldReturnViewWithPicture(bool isWithPicture)
       => MyViewComponent<RandomBlogPostComponent>
            .Instance()
            .WithData(GetBlog())
            .InvokedWith(v => v.Invoke(isWithPicture))
            .ShouldReturn()
            .View(v => v.WithModelOfType<SingleRandomBlogPostModel>(m => m.IsWithPicture
                .ShouldBe(isWithPicture)));
    }
}
