namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ProfileModels;

    public interface IProfileService
    {
        T GetUserById<T>(string id);

        DataManagerViewModel GetUserData(string id);

        IEnumerable<T> GetComments<T>(string id);

        Task CommentAsync(string appraiserId, CommentInputModel input);

        Task SavePictureAsync(ProfilePictureInputModel input, string pictureDirectory);

        string GetProfilePicturePath(string id);
    }
}
