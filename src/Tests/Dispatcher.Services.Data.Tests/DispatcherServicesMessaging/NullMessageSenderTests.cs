namespace Dispatcher.Services.Data.Tests.DispatcherServicesMessaging
{
    using Dispatcher.Services.Messaging;
    using Xunit;

    public class NullMessageSenderTests
    {
        [Fact]
        public void NullMessageSenderShouldReruenCompletedTask()
        {
            var nullMessangeSender = new NullMessageSender();

            var result = nullMessangeSender.SendEmailAsync("FromMe", "Ivan", "ToYou", "NoSubject", null, null).IsCompletedSuccessfully;

            Assert.True(result);
        }
    }
}
