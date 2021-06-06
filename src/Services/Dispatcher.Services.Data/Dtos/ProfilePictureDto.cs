namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Http;

    public class ProfilePictureDto : IMapFrom<ProfilePictureInputModel>
    {
        public string UserId { get; set; }

        public IFormFile Picture { get; set; }
    }
}
