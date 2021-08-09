namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class ProfilesControllerTests : BaseControllerTests
    {
        [Theory]
        [InlineData("Ivan_Dev")]
        public void ProfileSchouldRedirectToActionWhenUsernameNotFound(string username)
            => MyMvc.Controller<ProfilesController>()
                .WithUser()
                .WithoutData()
                .Calling(c => c.Profile(username))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Error", "Home");

        [Fact]
        public void ProfileSchouldReturnViewWithTheCurrentLoggedInUserWhenTheUsernameIsEmpty()
           => MyMvc.Controller<ProfilesController>()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(GetUser())
               .Calling(c => c.Profile(null))
               .ShouldHave()
               .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .View(v => v
                    .WithModelOfType<ProfileViewModel>());

        [Theory]
        [InlineData("AnotherUser")]
        public void Data(string anotherUser)
         => MyMvc.Controller<ProfilesController>()
             .WithUser(u => u.WithIdentifier(UserId))
             .WithData(GetUser())
             .Calling(c => c.DataManager(anotherUser))
             .ShouldHave()
             .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
             .AndAlso()
             .ShouldReturn()
             .Unauthorized();
    }
}
