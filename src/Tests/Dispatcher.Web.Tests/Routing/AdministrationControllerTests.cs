namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Areas.Administration.Controllers;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class AdministrationControllerTests
    {
        [Fact]
        public void GetDataRouteShouldBeMapped()
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath("/Administration/Administration/GetData")
               .WithMethod(HttpMethod.Post))
          .To<AdministrationController>(c => c
              .GetData(new SearchInputModel()));

        [Theory]
        [InlineData("fakeId")]
        public void DeleteUserShouldBeMapped(string userId)
            => MyRouting
            .Configuration()
            .ShouldMap($"/Administration/Administration/DeleteUser/{userId}")
            .To<AdministrationController>(c => c
                .DeleteUser(userId));

        [Theory]
        [InlineData(1)]
        public void DeleteReviewShouldBeMapped(int id)
            => MyRouting
            .Configuration()
            .ShouldMap($"/Administration/Administration/DeleteReview/{id}")
            .To<AdministrationController>(c => c
                .DeleteReview(id));
    }
}
