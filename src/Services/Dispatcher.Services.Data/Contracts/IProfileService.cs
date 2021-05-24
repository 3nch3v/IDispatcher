namespace Dispatcher.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.ProfileModels;

    public interface IProfileService
    {
        T GetUserById<T>(string id);

        IEnumerable<T> GetComments<T>(string id);

        Task CommentAsync(string appraiserId, CommentInputModel input);
    }
}
