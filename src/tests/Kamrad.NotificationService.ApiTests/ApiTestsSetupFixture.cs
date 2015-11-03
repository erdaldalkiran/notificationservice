using Kamrad.NotificationService.Api;
using NUnit.Framework;

namespace Kamrad.NotificationService.ApiTests
{
    [SetUpFixture]
    public class ApiTestsSetupFixture
    {
        private readonly NancySelfHost apiHost = new NancySelfHost();

        [SetUp]
        public void SetUp()
        {
            apiHost.Start();
        }

        [TearDown]
        public void TearDown()
        {
            apiHost.Stop();
        }
    }
}