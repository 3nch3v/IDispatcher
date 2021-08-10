namespace Dispatcher.Web.Tests.Controllers
{
    using System.Linq;

    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class CustomersReviewsControllerTests : BaseControllerTests
    {
        [Theory]
        [InlineData(3)]
        public void AllShouldReturnAllCommentsViewModelViewModel(int expectedCount)
             => MyController<CustomersReviewsController>
                    .Instance()
                    .WithUser(u => u.WithIdentifier(UserId))
                    .WithData(data => data
                        .WithEntities(entities => entities
                            .AddRange(GetComments()))
                        .AndAlso()
                        .WithEntities(
                            GetUser(),
                            GetFakeUser()))
                    .Calling(c => c.All(UserId))
                    .ShouldReturn()
                    .View(view => view
                        .WithModelOfType<AllCommentsViewModel>(m => m.Comments.Count()
                           .ShouldBe(expectedCount)));

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsInvalid()
           => MyMvc
           .Controller<CustomersReviewsController>(instance => instance
               .WithUser())
           .Calling(c => c.Comment(new CommentInputModel(), UserId))
           .ShouldHave()
           .ActionAttributes(a => a
              .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldHave()
           .ActionAttributes(a => a.
               ContainingAttributeOfType<HttpPostAttribute>())
           .AndAlso()
           .ShouldHave()
           .InvalidModelState()
           .AndAlso()
           .ShouldReturn()
           .RedirectToAction("All");

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToAllWhenModelStateIsValid()
          => MyMvc
           .Controller<CustomersReviewsController>(instance => instance
               .WithUser())
           .Calling(c => c.Comment(
                GetCommenInput(),
                UserId))
           .ShouldHave()
           .ActionAttributes(a => a
              .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldHave()
           .ActionAttributes(a => a.
               ContainingAttributeOfType<HttpPostAttribute>())
           .AndAlso()
           .ShouldHave()
           .ValidModelState()
           .AndAlso()
           .ShouldReturn()
           .RedirectToAction("All", new { id = UserId });
    }
}
