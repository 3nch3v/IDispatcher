namespace Dispatcher.Services.Data.Dtos
{
    using System;

    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfilePicturesDto : IMapFrom<ProfilePicture>
    {
        public string FilePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
