namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IFilesService
    {
        void DeleteFile(string pictureDirectory, string pictureId, string pictureExtension);

        Task SaveFileAsync(byte[] picture, string pictureDirectory, string pictureId, string pictureExtension);
    }
}
