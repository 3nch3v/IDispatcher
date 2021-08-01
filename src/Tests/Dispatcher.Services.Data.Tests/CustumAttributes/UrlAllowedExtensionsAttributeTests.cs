namespace Dispatcher.Services.Data.Tests.CustumAttributes
{
    using Dispatcher.Data.Common.CustomAttributes;
    using Xunit;

    public class UrlAllowedExtensionsAttributeTests
    {
        private readonly string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        [Fact]
        public void AttributeShouldValidateCorrectValidUrlAndReturnTrue()
        {
            string validJpg = "https://www.spiel.de/Pictures-scaled.jpg";
            string validPng = "https://www.spiel.de/Pictures-scaled.png";
            string validBmp = "https://www.spiel.de/Pictures-scaled.bmp";
            string validGif = "https://www.spiel.de/Pictures-scaled.gif";
            string validJpeg = "https://www.spiel.de/Pictures-scaled.jpeg";
            var attribute = new UrlAllowedExtensionsAttribute(this.allowedExtensions);

            bool jpg = attribute.IsValid(validJpg);
            bool png = attribute.IsValid(validPng);
            bool bmp = attribute.IsValid(validBmp);
            bool gif = attribute.IsValid(validGif);
            bool jpeg = attribute.IsValid(validJpeg);

            Assert.True(jpg);
            Assert.True(png);
            Assert.True(bmp);
            Assert.True(gif);
            Assert.True(jpeg);
        }

        [Fact]
        public void AttributeShouldValidateCorrectInvalidUrlAndReturnFalse()
        {
            string invalidExe = "https://www.spiel.de/Pictures-scaled.exe";
            string invalidPdf = "https://www.spiel.de/Pictures-scaled.pdf";
            string invalidEps = "https://www.spiel.de/Pictures-scaled.eps";
            string invalidRaw = "https://www.spiel.de/Pictures-scaled.raw";
            var attribute = new UrlAllowedExtensionsAttribute(this.allowedExtensions);

            bool exe = attribute.IsValid(invalidExe);
            bool pdf = attribute.IsValid(invalidPdf);
            bool eps = attribute.IsValid(invalidEps);
            bool raw = attribute.IsValid(invalidRaw);

            Assert.False(exe);
            Assert.False(pdf);
            Assert.False(eps);
            Assert.False(raw);
        }
    }
}
