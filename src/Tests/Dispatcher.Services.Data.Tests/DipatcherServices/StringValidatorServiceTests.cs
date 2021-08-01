namespace Dispatcher.Services.Data.Tests
{
    using Xunit;

    public class StringValidatorServiceTests
    {
        [Fact]
        public void IsStringValidShouldCorrectState()
        {
            int minStringLenght = 10;

            string whiteSpace = "                                 ";
            string whiteSpaceEnclosedHtml = "<p>          <div> </div>         <p>";
            string underMinLenghtEnclosedHtml = "<p>          <div><p>False</p></div>         <p>";
            string emptyString = string.Empty;
            string unterMinLenght = "Test";
            string validString = "<div>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</div>";

            var service = new StringValidatorService();

            bool whiteSpaceExpectedFalse = service.IsStringValid(whiteSpace, minStringLenght);
            bool whiteSpaceInsideHtmlTagExpectedFalse = service.IsStringValid(whiteSpaceEnclosedHtml, minStringLenght);
            bool underMinLenghtEnclosedHtmlExpectedFalse = service.IsStringValid(underMinLenghtEnclosedHtml, minStringLenght);
            bool emptyStringExpectedFalse = service.IsStringValid(emptyString, minStringLenght);
            bool underMinLenghtExpectedFalse = service.IsStringValid(unterMinLenght, minStringLenght);
            bool expectedTrue = service.IsStringValid(validString, minStringLenght);

            Assert.False(whiteSpaceExpectedFalse);
            Assert.False(whiteSpaceInsideHtmlTagExpectedFalse);
            Assert.False(underMinLenghtEnclosedHtmlExpectedFalse);
            Assert.False(emptyStringExpectedFalse);
            Assert.False(underMinLenghtExpectedFalse);
            Assert.True(expectedTrue);
        }
    }
}
