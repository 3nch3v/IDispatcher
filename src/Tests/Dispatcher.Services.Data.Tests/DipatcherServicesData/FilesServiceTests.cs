namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class FilesServiceTests
    {
        [Fact]
        public async Task SaveFileAsyncShouldSaveSuccessfullyGivenFileInTheSystem()
        {
            var service = new FilesService();
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy file")), 0, 2, "Data", "test.txt");
            string path = Directory.GetCurrentDirectory();

            await service.SaveFileAsync(file, path, "test", ".txt");
            FileInfo fileInfo = new($"{path}/test.txt");

            Assert.True(fileInfo.Exists);
        }

        [Fact]
        public void DeleteFileShouldDeleteSuccessfullyExistingFileInTheSystem()
        {
            var service = new FilesService();
            string path = Directory.GetCurrentDirectory();

            service.DeleteFile(path, "test", ".txt");

            FileInfo fileInfo = new($"{path}/test.txt");
            Assert.False(fileInfo.Exists);
        }
    }
}
