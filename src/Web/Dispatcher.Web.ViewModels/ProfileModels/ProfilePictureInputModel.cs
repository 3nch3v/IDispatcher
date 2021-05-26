namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Microsoft.AspNetCore.Http;

    public class ProfilePictureInputModel
    {
        public string UserId { get; set; }

        public IFormFile Picture { get; set; }
    }
}
