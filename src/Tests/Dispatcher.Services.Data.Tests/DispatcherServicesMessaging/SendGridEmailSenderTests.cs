namespace Dispatcher.Services.Data.Tests.DispatcherServicesMessaging
{
    using Dispatcher.Services.Messaging;
    using Xunit;

    public class SendGridEmailSenderTests
    {
        [Theory]
        [InlineData("myFakeKey")]
        public void SendGridEmailSenderShouldTrowExceptionWhenSubjectOrHtmlContentIsEmpty(string key)
        {
            var sengrid = new SendGridEmailSender(key);

            var result = sengrid.SendEmailAsync("FromMe", "Ivan", "ToYou", null, null, null).IsFaulted;

            Assert.True(result);
        }
    }
}
