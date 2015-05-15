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

                usersClient.Buckets.GetAllBuckets("username");

                client.Received().GetAll<Bucket>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Buckets.GetAllBuckets(null));
            }
        }

        public class TheGetAllBucketsForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/buckets", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Buckets.GetAllBucketsForCurrent();

                client.Received().GetAll<Bucket>(endpoint);
            }
        }

        public class TheGetAllShotsUserFollowedForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/following/shots", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Followers.GetAllShotsUsersFollowedForCurrent();

                client.Received().GetAll<Shot>(endpoint);
            }
        }

        public class TheGetAllShotLikesMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/likes", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Likes.GetAllShotLikes("username");

                client.Received().GetAll<Like>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Likes.GetAllShotLikes(null));
            }
        }

        public class TheGetAllShotLikesForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/likes", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Likes.GetAllShotLikesForCurrent();

                client.Received().GetAll<Like>(endpoint);
            }
        }

        public class TheGetAllProjectsMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/projects", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Projects.GetAllProjects("username");

                client.Received().GetAll<Project>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Projects.GetAllProjects(null));
            }
        }

        public class TheGetAllProjectsForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/projects", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Projects.GetAllProjectsForCurrent();

                client.Received().GetAll<Project>(endpoint);
            }
        }

        public class TheGetAllShotsMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/shots", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Shots.GetAllShots("username");

                client.Received().GetAll<Shot>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Shots.GetAllShots(null));
            }
        }

        public class GetAllShotsForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/shots", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Shots.GetAllShotsForCurrent();

                client.Received().GetAll<Shot>(endpoint);
            }
        }

        public class GetAllTeamsMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("users/username/teams", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Teams.GetAllTeams("username");

                client.Received().GetAll<Team>(endpoint);
            }

            [Fact]
            public async Task ThrowsIfGivenNullUser()
            {
                var userEndpoint = new UsersClient(Substitute.For<IApiConnection>());
                await AssertEx.Throws<ArgumentNullException>(() => userEndpoint.Teams.GetAllTeams(null));
            }
        }

        public class GetAllTeamsForCurrentMethod
        {
            [Fact]
            public void RequestsCorrectUrl()
            {
                var endpoint = new Uri("user/teams", UriKind.Relative);
                var client = Substitute.For<IApiConnection>();
                var usersClient = new UsersClient(client);

                usersClient.Teams.GetAllTeamsForCurrent();

                client.Received().GetAll<Team>(endpoint);
            }
        }
    }
}
