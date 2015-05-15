using Dddesignkit.Internal;
using Dddesignkit.Tests.Helpers;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Clients
{
    public class FollowersClientTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ThrowsBadArgs()
            {
                Assert.Throws<ArgumentNullException>(() => new FollowersClient(null));
            }
        }

        public class TheGetAllFollowersMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/followers", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Followers.GetAllFollowers("username");

                client.Received().GetAll<Followers>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Followers.GetAllFollowers(null));
            }
        }

        public class TheGetAllFollowersForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/followers", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Followers.GetAllFollowersForCurrent();

                client.Received().GetAll<Followers>(endpoint);
            }
        }

        public class TheGetAllFollowingMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/following", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Followers.GetAllFollowing("username");

                client.Received().GetAll<Following>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Followers.GetAllFollowing(null));
            }
        }

        public class TheGetAllFollowingForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/following", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Followers.GetAllFollowingForCurrent();

                client.Received().GetAll<Following>(endpoint);
            }
        }

        public class TheIsFollowingForCurrentMethod
        {
            [Theory]
            [InlineData(HttpStatusCode.NoContent, true)]
            [InlineData(HttpStatusCode.NotFound, false)]
            public async Task RequestsCorrectValueForStatusCode(HttpStatusCode status, bool expected)
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(status, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Arg.Is<Uri>(u => u.ToString() == "user/following/meidenberg"),
                    null, null).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                var result = await client.IsFollowingForCurrent("meidenberg");

                Assert.Equal(expected, result);
            }

            [Fact]
            public async Task ThrowsExceptionForInvalidStatusCode()
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(HttpStatusCode.Conflict, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Arg.Is<Uri>(u => u.ToString() == "user/following/meidenberg"),
                    null, null).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                await AssertEx.Throws<ApiException>(() => client.IsFollowingForCurrent("meidenberg"));
            }

            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FollowersClient(connection);

                await AssertEx.Throws<ArgumentNullException>(() => client.IsFollowingForCurrent(null));
                await AssertEx.Throws<ArgumentException>(() => client.IsFollowingForCurrent(""));
            }
        }

        public class TheIsFollowingMethod
        {
            [Theory]
            [InlineData(HttpStatusCode.NoContent, true)]
            [InlineData(HttpStatusCode.NotFound, false)]
            public async Task RequestsCorrectValueForStatusCode(HttpStatusCode status, bool expected)
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(status, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Arg.Is<Uri>(u => u.ToString() == "users/meidenberg/following/meidenberg-test"),
                    null, null).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                var result = await client.IsFollowing("meidenberg", "meidenberg-test");

                Assert.Equal(expected, result);
            }

            [Fact]
            public async Task ThrowsExceptionForInvalidStatusCode()
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(HttpStatusCode.Conflict, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Arg.Is<Uri>(u => u.ToString() == "users/meidenberg/following/meidenberg-test"),
                    null, null).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                await AssertEx.Throws<ApiException>(() => client.IsFollowing("meidenberg", "meidenberg-test"));
            }

            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FollowersClient(connection);

                await AssertEx.Throws<ArgumentNullException>(() => client.IsFollowing(null, "meidenberg-test"));
                await AssertEx.Throws<ArgumentNullException>(() => client.IsFollowing("meidenberg", null));
                await AssertEx.Throws<ArgumentException>(() => client.IsFollowing("", "meidenberg-text"));
                await AssertEx.Throws<ArgumentException>(() => client.IsFollowing("meidenberg", ""));
            }

        }

        public class TheFollowMethod
        {
            [Theory]
            [InlineData(HttpStatusCode.NoContent, true)]
            public async Task RequestsCorrectValueForStatusCode(HttpStatusCode status, bool expected)
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(status, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Put<object>(Arg.Is<Uri>(u => u.ToString() == "users/meidenberg/follow"),
                    Args.Object).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                var result = await client.Follow("meidenberg");

                Assert.Equal(expected, result);
            }

            [Fact]
            public async Task ThrowsExceptionForInvalidStatusCode()
            {
                var response = Task.Factory.StartNew<IApiResponse<object>>(() =>
                    new ApiResponse<object>(new Response(HttpStatusCode.Conflict, null, new Dictionary<string, string>(), "application/json")));
                var connection = Substitute.For<IConnection>();
                connection.Put<object>(Arg.Is<Uri>(u => u.ToString() == "users/meidenberg/follow"),
                    new { }).Returns(response);
                var apiConnection = Substitute.For<IApiConnection>();
                apiConnection.Connection.Returns(connection);
                var client = new FollowersClient(apiConnection);

                await AssertEx.Throws<ApiException>(() => client.Follow("meidenberg"));
            }

            [Fact]
            public async Task EnsureNonNullArguments()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FollowersClient(connection);

                await AssertEx.Throws<ArgumentNullException>(async () => await client.Follow(null));
                await AssertEx.Throws<ArgumentException>(async () => await client.Follow(""));
            }
        }

        public class TheUnfollowMethod
        {
            [Fact]
            public void RequestsTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FollowersClient(connection);

                client.Unfollow("meidenberg");

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "users/meidenberg/follow"));
            }

            [Fact]
            public async Task EnsureNonNullArguments()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FollowersClient(connection);

                await AssertEx.Throws<ArgumentNullException>(async () => await client.Unfollow(null));
                await AssertEx.Throws<ArgumentException>(async () => await client.Unfollow(""));
            }
        }
    }
}
