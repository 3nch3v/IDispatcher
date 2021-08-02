namespace Dispatcher.Services.Data.Tests.CustumAttributes
{
    using System.IO;
    using System.Text;

    using Dispatcher.Data.Common.CustomAttributes;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class MaxFileSizeAttributeTests
    {
        [Fact]
        public void MaxFileSizeAttributeShouldReturnTrueIfTheFileIsSamllerThanMaxFileSize()
        {
            var attribute = new MaxFileSizeAttribute(5 * 1024 * 1024);
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 10, "Data", "fake.jpg");

            var actualResult = attribute.IsValid(file);

            Assert.True(actualResult);
        }

        [Fact]
        public void MaxFileSizeAttributeShouldReturnFalseIfTheFileIsBiggerThanMaxFileSize()
        {
            var attribute = new MaxFileSizeAttribute(500);
            IFormFile fileJpg = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 1024, "Data", "fake.jpg");

            var actualResult = attribute.IsValid(fileJpg);

            Assert.False(actualResult);
        }
    }
}
