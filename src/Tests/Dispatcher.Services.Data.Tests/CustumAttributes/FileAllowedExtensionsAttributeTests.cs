namespace Dispatcher.Services.Data.Tests.CustumAttributes
{
    using System.IO;
    using System.Text;

    using Dispatcher.Data.Common.CustomAttributes;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class FileAllowedExtensionsAttributeTests
    {
        [Fact]
        public void FileAllowedExtensionsAttributeShuldReturnTrueIfFileExtensionIsInAllowed()
        {
            var attribute = new FileAllowedExtensionsAttribute(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" });
            IFormFile fileJpg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "fake.jpg");
            IFormFile fileJpeg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "fake.jpeg");
            IFormFile filePng = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "fake.png");
            IFormFile fileGif = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "fake.gif");
            IFormFile fileBmp = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "fake.bmp");

            var actualResultJpg = attribute.IsValid(fileJpg);
            var actualResultJpeg = attribute.IsValid(fileJpeg);
            var actualResultPng = attribute.IsValid(filePng);
            var actualResultGif = attribute.IsValid(fileGif);
            var actualResultBmp = attribute.IsValid(fileBmp);

            Assert.True(actualResultJpg);
            Assert.True(actualResultJpeg);
            Assert.True(actualResultPng);
            Assert.True(actualResultGif);
            Assert.True(actualResultBmp);
        }

        [Fact]
        public void FileAllowedExtensionsAttributeShuldReturnFalseIfFileExtensionIsNotAllowed()
        {
            var attribute = new FileAllowedExtensionsAttribute(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" });
            IFormFile fileExe = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy file")), 0, 0, "Data", "fake.exe");
            IFormFile fileTxt = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy file")), 0, 0, "Data", "fake.txt");
            IFormFile filePdf = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy file")), 0, 0, "Data", "fake.pdf");
            IFormFile fileDoc = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy file")), 0, 0, "Data", "fake.doc");

            var actualResultExe = attribute.IsValid(fileExe);
            var actualResultTxt = attribute.IsValid(fileTxt);
            var actualResultPdf = attribute.IsValid(filePdf);
            var actualResultDoc = attribute.IsValid(fileDoc);

            Assert.False(actualResultExe);
            Assert.False(actualResultTxt);
            Assert.False(actualResultPdf);
            Assert.False(actualResultDoc);
        }
    }
}
