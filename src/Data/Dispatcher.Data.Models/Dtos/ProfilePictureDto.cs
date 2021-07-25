namespace Dispatcher.Data.Models.Dtos
{
    using Microsoft.AspNetCore.Http;

    public class ProfilePictureDto
    {
        public string UserId { get; set; }

        public IFormFile Picture { get; set; }
    }
}
