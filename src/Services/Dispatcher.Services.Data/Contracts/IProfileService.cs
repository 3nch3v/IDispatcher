﻿namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Web.ViewModels.ProfileModels;

    public interface IProfileService
    {
        string GetProfilePicturePath(string id);

        ProfileDataDto GetUserById(string id);

        DataManagerDto GetUserData(string id);

        IEnumerable<T> GetComments<T>(string id);

        Task CommentAsync<T>(string appraiserId, T input);

        Task SavePictureAsync(ProfilePictureInputModel input, string pictureDirectory);
    }
}
