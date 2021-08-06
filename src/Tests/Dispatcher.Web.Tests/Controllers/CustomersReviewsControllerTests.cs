namespace Dispatcher.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Reflection;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CustomersReviewsControllerTests
    {
        public CustomersReviewsControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

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

        private static IEnumerable<CustomerReview> GetComments()
        {
            return new List<CustomerReview>
            {
                new CustomerReview
                {
                    Id = 1,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 5,
                    Comment = "ok",
                },
                new CustomerReview
                {
                    Id = 2,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 3,
                    Comment = "super",
                },
                new CustomerReview
                {
                    Id = 3,
                    AppraiserId = "fakeId",
                    UserId = UserId,
                    StarsCount = 1,
                    Comment = "top",
                },
            };
        }
    }
}
