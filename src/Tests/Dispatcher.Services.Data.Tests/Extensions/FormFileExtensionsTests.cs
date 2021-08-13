namespace Dispatcher.Services.Data.Tests.Extensions
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Dispatcher.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class FormFileExtensionsTests
    {
        [Fact]
        public async Task FileAllowedExtensionsAttributeShuldReturnTrueIfFileExtensionIsInAllowed()
        {
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 10, "Data", "fake.jpg");
            var result = await FormFileExtensions.GetBytesAsync(file);

            Assert.NotEmpty(result);
            Assert.Equal(10, result.Length);
        }
    }
}
