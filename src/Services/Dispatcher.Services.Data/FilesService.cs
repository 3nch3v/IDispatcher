namespace Dispatcher.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class FilesService : IFilesService
    {
        public async Task SaveFileAsync(
            IFormFile picture,
            string pictureDirectory,
            string pictureId,
            string pictureExtension)
        {
            string physicalFilePath = $"{pictureDirectory}/{pictureId}{pictureExtension}";
            var fileStream = new FileStream(physicalFilePath, FileMode.Create);
            await picture.CopyToAsync(fileStream);
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
