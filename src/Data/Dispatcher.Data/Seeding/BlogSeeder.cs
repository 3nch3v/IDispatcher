namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.BlogModels;

    public class BlogSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Blogs.Any())
            {
                return;
            }

            var blogs = new List<Blog>();

            for (int i = 0; i < 12; i++)
            {
                blogs.Add(new Blog
                {
                    Title = $"{i} C# Masters",
                    Body = $"As you explore more with strings, you'll find that strings are more than a collection of letters. " +
                            $"You can find the length of a string using Length. Length is a property of a string and it returns the number" +
                            $" of characters in that string. Add the following code at the bottom of the interactive window:",
                    UserId = "b74947e2-05e2-4279-adc6-a86ca3f1e4cf",
                    PictureFileName = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
                });
            }

            await dbContext.Blogs.AddRangeAsync(blogs);
        }
    }
}
