namespace Dispatcher.Web.Tests.Controllers
{
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProfilesControllerTests
    {
        public ProfilesControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

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

        private static ApplicationUser GetUser()
        {
            return new ApplicationUser
            {
                Id = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                UserName = "Ivan_Dev",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }
    }
}
