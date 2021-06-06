namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Dtos;
    using Dispatcher.Web.ViewModels.ProfileModels;

    public interface IProfileService
    {
        T GetUserById<T>(string id);

        IEnumerable<T> GetComments<T>(string id);

        Task CommentAsync<T>(string appraiserId, T input);

        Task SavePictureAsync(ProfilePictureInputModel input, string pictureDirectory);

        DataManagerDto GetUserData(string id);

        string GetProfilePicturePath(string id);
    }
}
