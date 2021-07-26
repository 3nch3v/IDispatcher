namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using static Dispatcher.Common.GlobalConstants.User;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(
            ApplicationDbContext dbContext,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var admin = new ApplicationUser
            {
                UserName = configuration["AdminData:Username"],
                Email = configuration["AdminData:Email"],
            };
            var result = userManager.CreateAsync(admin, configuration["AdminData:Password"]).Result;
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, AdministratorRole);
            }

            var userIvan = new ApplicationUser
            {
                Id = configuration["UserIvan:Id"],
                UserName = "Ivan_Dev",
                Email = "ivan@fake.bg",
                FirstName = "Ivan",
                LastName = "Enchev",
                Education = "C# Master",
                CompanyName = "Hacker Inc.",
                Interest = "C#, CSS, HTML, JS, Hacking",
                Contact = "ivan@fake.bg",
                WebsiteUrl = "dir.bg",
                GithubUrl = "github.com/3nch3v",
                FacebookUrl = "facebook.com/3nch3v",
                InstagramUrl = "https://www.instagram.com/",
                PhoneNumber = "0887-88-97-88-78",
            };
            var userIvanResult = userManager.CreateAsync(userIvan, configuration["UserIvan:Password"]).Result;
            if (userIvanResult.Succeeded)
            {
                await userManager.AddToRoleAsync(userIvan, UserRole);
            }

            var userBeroec = new ApplicationUser
            {
                Id = configuration["UserBeroe:Id"],
                UserName = "Beroe1916",
                Email = "beroe@fake.bg",
                FirstName = "Beroe",
                LastName = "Champion",
                Education = "Master of Computer Science",
                CompanyName = "Beroe Inc.",
                Interest = "C#, Soccer",
                Contact = "beroe@fake.bg",
                WebsiteUrl = "beroe.bg",
                GithubUrl = "github.com",
                FacebookUrl = "facebook.com/",
                InstagramUrl = "www.instagram.com/",
                PhoneNumber = "0887-98-97-77-78",
            };
            var userBeroecResult = userManager.CreateAsync(userBeroec, configuration["UserBeroe:Password"]).Result;
            if (userBeroecResult.Succeeded)
            {
                await userManager.AddToRoleAsync(userBeroec, UserRole);
            }

            var userHans = new ApplicationUser
            {
                Id = configuration["UserHans:Id"],
                UserName = "Hans-1860",
                Email = "bayern@fake.bg",
                FirstName = "Hans",
                LastName = "Muenchev1860",
                Education = "Java Entwickler",
                CompanyName = "Tarasch GmbH",
                Interest = "Java, Beer",
                Contact = "hans@fake.bg",
                WebsiteUrl = "www.muenchen.de/",
                GithubUrl = "github.com",
                FacebookUrl = "facebook.com/",
                InstagramUrl = "www.instagram.com/",
                PhoneNumber = "+042 (0)173-98-97-77-78",
            };
            var userHansResult = userManager.CreateAsync(userHans, configuration["UserHans:Password"]).Result;
            if (userHansResult.Succeeded)
            {
                await userManager.AddToRoleAsync(userHans, UserRole);
            }
        }
    }
}
