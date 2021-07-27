namespace Dispatcher.Data.Models.Dtos
{
    using Microsoft.AspNetCore.Http;

    public class BlogPostDto
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string VideoLink { get; set; }

        public IFormFile Picture { get; set; }
    }
}
