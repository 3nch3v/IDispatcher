namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.Dtos;

    public interface IProfilesService
    {
        string GetProfilePicturePath(string id);

        ProfileDataDto GetUserById(string userId);

        DataManagerDto GetUserData(string id);

        IEnumerable<T> GetComments<T>(string id);

        Task CommentAsync<T>(string appraiserId, T input);

        Task SetProfilePictureAsync(string userId, byte[] picture, string pictureExtension, string picturePath);
    }
}
