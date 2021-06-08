namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfilePicturesCollectionViewModel : IMapFrom<ProfilePicture>
    {
        public string FilePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
