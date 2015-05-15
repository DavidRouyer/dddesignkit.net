using Dddesignkit.Tests.Helpers;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Clients
{
    public class ShotsClientTests
    {
        public class TheConstructor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ShotsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public void RequestsTheCorrectUrlAndReturnsShots()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ShotsClient(connection);

                client.GetAll();

                connection.Received()
                    .GetAll<Shot>(Arg.Is<Uri>(u => u.ToString() == "shots"));
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("shots/42", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var shotsClient = new ShotsClient(client);

                shotsClient.Get(42);

                client.Received().Get<Shot>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Get(null));
            }
        }
    }
}
