namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.ForumModels;
    using Microsoft.Extensions.Configuration;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(
            ApplicationDbContext dbContext,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category { Name = "News" },
                new Category { Name = "Education" },
                new Category { Name = "Hardware" },
                new Category { Name = "Help" },
                new Category { Name = "Games" },
                new Category { Name = "Software" },
            };

            await dbContext.Categories.AddRangeAsync(categories);
        }
    }
}
