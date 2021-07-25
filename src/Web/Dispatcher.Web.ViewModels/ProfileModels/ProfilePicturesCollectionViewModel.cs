namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System;

    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfilePicturesCollectionViewModel : IMapFrom<ProfilePicture>, IMapFrom<ProfilePicturesDto>
    {
        public string FilePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
