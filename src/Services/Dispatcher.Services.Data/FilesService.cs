namespace Dispatcher.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Contracts;

    public class FilesService : IFilesService
    {
        public async Task SaveFileAsync(
            byte[] picture,
            string pictureDirectory,
            string pictureId,
            string pictureExtension)
        {
            string physicalFilePath = $"{pictureDirectory}/{pictureId}{pictureExtension}";

            await File.WriteAllBytesAsync(physicalFilePath, picture);
        }

        public void DeleteFile(
            string pictureDirectory,
            string pictureId,
            string pictureExtension)
        {
            string physicalFilePath = $"{pictureDirectory}/{pictureId}{pictureExtension}";

            FileInfo file = new(physicalFilePath);

            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
