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

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"As you explore more with strings, you'll find that strings are more than a collection of letters. " +
                $"You can find the length of a string using Length. Length is a property of a string and it returns the number" +
                $" of characters in that string. Add the following code at the bottom of the interactive window:",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://media.nature.com/w1172/magazine-assets/d41586-017-08492-y/d41586-017-08492-y_15320844.jpg",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"The square brackets [ and ] help visualize what the Trim, TrimStart and TrimEnd methods do. " +
                $"The brackets show where whitespace starts and ends. This sample reinforces a couple of important concepts " +
                $"for working with strings.The methods that manipulate strings return new string objects rather than making" +
                $" modifications in place.You can see that each call to any of the Trim methods returns a new string but doesn't " +
                $"change the original message. There are other methods available to work with a string.For example, " +
                $"you've probably used a search and replace command in an editor or word processor before. The Replace " +
                $"method does something similar in a string. It searches for a substring and replaces it with different text. The" +
                $" Replace method takes two parameters. These are the strings between the parentheses. The first string is the" +
                $" text to search for. The second string is the text to replace it with. Try it for yourself. Add this code." +
                $" Type it in to see the hints as you start typing .Re after the sayHello variable:",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://www.rd.com/wp-content/uploads/2018/12/50-Funny-Animal-Pictures-That-You-Need-In-Your-Life-45.jpg?resize=768,510",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://www.rd.com/wp-content/uploads/2018/12/50-Funny-Animal-Pictures-That-You-Need-In-Your-Life-2.jpg?resize=768,512",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://www.rd.com/wp-content/uploads/2018/12/50-Funny-Animal-Pictures-That-You-Need-In-Your-Life-4.jpg?resize=768,508",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"You've been using a method, Console.WriteLine, to print messages. A method is a block of code that " +
                $"implements some action. It has a name, so you can access it. Suppose your strings have leading or " +
                $"trailing spaces that you don't want to display. You want to trim the spaces from the strings. " +
                $"The Trim method and related methods TrimStart and TrimEnd do that work. You can just use those" +
                $" methods to remove leading and trailing spaces. Try the following code:",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://www.rd.com/wp-content/uploads/2018/12/50-Funny-Animal-Pictures-That-You-Need-In-Your-Life-6.jpg?resize=768,512",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"The window has a feature called IntelliSense that makes. This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. " +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
            });

            blogs.Add(new Blog
            {
                Title = "C# Masters",
                Body = $"123455 This is a good time to explore on your own. You've learned that Console.WriteLine() writes" +
               $" text to the screen. You've learned how to declare variables and concatenate strings together. " +
               $"Experiment in the interactive window. The window has a feature called IntelliSense that makes" +
               $" suggestions for what you can do. Type a . after the d in firstFriend. You'll see a list of suggestions " +
               $"for properties and methods you can use.",
                UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                RemotePictureUrl = "https://writtent.com/blog/wp-content/uploads/2013/03/picture-citing-lion-noble.jpg",
            });

            await dbContext.Blogs.AddRangeAsync(blogs);
        }
    }
}
