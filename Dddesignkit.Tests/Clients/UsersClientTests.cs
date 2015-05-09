using Dddesignkit.Clients;
using Dddesignkit.Tests.Helpers;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Clients
{
    public class UsersClientTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ThrowsBadArgs()
            {
                Assert.Throws<ArgumentNullException>(() => new UsersClient(null));
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Get("username");

                client.Received().Get<User>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Get(null));
            }
        }

        public class TheCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Current();

                client.Received().Get<User>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Get(null));
            }
        }

        public class TheGetAllBucketsMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/buckets", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.GetAllBuckets("username");

                client.Received().GetAll<Bucket>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.GetAllBuckets(null));
            }
        }
    }
}
