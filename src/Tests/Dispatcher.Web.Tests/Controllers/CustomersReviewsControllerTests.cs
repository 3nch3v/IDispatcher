namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class CustomersReviewsControllerTests : BaseControllerTests
    {
        [Fact]
        public void AllShouldReturnAllCommentsViewModelViewModel()
              => MyController<CustomersReviewsController>
                     .Instance()
                     .WithUser(u => u.WithIdentifier(UserId))
                     .WithData(data => data
                        .WithEntities(entities => entities
                            .AddRange(GetComments())))
                     .Calling(c => c.All(UserId))
                     .ShouldReturn()
                     .View(view => view
                         .WithModelOfType<AllCommentsViewModel>());

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
           .Calling(c => c.Comment(new CommentInputModel() { StarsCount = 3, Comment = "Ok super", UserId = UserId }, UserId))
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
           .RedirectToAction("All");
    }
}
