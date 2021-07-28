namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        void DeleteFile(string pictureDirectory, string pictureId, string pictureExtension);

        Task SaveFileAsync(IFormFile picture, string pictureDirectory, string pictureId, string pictureExtension);
    }
}
