using Dddesignkit.Tests.Helpers;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Clients
{
    class BucketsClientTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ThrowsBadArgs()
            {
                Assert.Throws<ArgumentNullException>(() => new BucketsClient(null));
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("buckets/1", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var bucketsClient = new BucketsClient(client);

                bucketsClient.Get(1);

                client.Received().Get<Bucket>(endpoint);
            }
        }
    }
}
