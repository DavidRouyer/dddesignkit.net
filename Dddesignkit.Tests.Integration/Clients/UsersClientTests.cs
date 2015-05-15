using Dddesignkit;
using Dddesignkit.Tests.Integration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class UsersClientTests
{
    readonly IDribbbleClient _dribbble;
    readonly User _currentUser;

    public UsersClientTests()
    {
        _dribbble = Helper.GetAuthenticatedClient();
        _currentUser = _dribbble.User.Current().Result;
    }

    public class TheGetMethod
    {
        [IntegrationTest]
        public async Task ReturnsSpecifiedUser()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var user = await dribbble.User.Get("simplebits");

            Assert.Equal(1, user.Id);
        }
    }

    public class TheCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsCurrentUser()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var user = await dribbble.User.Current();

            Assert.Equal(Helper.UserName, user.Username);

        }
    }

    public class TheGetAllBucketsMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllUserBuckets()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var buckets = await dribbble.User.Buckets.GetAllBuckets("simplebits");

            Assert.True(buckets.Count >= 10);
        }
    }

    public class TheGetAllBucketsForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllUserBucketsForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var buckets = await dribbble.User.Buckets.GetAllBucketsForCurrent();

            Assert.True(buckets.Count >= 0);
        }
    }

    public class TheGetAllFollowersMethod
    {
        [IntegrationTest(Skip = "Takes too long to run.")]
        public async Task ReturnsAllUserFollowers()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var followers = await dribbble.User.Followers.GetAllFollowers("simblebits");

            Assert.True(followers.Count >= 10);
        }
    }

    public class TheGetAllFollowersForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllUserFollowersForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var followers = await dribbble.User.Followers.GetAllFollowersForCurrent();

            Assert.True(followers.Count >= 1);
        }
    }

    public class TheGetAllFollowingMethod
    {
        [IntegrationTest(Skip = "Takes too long to run.")]
        public async Task ReturnsAllUserFollowing()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var following = await dribbble.User.Followers.GetAllFollowing("simplebits");

            Assert.True(following.Count >= 10);
        }
    }

    public class TheGetAllFollowingForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllUserFollowingForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var following = await dribbble.User.Followers.GetAllFollowingForCurrent();

            Assert.True(following.Count >= 10);
        }
    }

    public class TheGetAllShotsUserFollowedForCurrentMethod
    {
        [IntegrationTest(Skip = "Takes too long to run.")]
        public async Task ReturnsAllShotsUserFollowedForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var shotsFollowed = await dribbble.User.Followers.GetAllShotsUsersFollowedForCurrent();

            Assert.True(shotsFollowed.Count >= 10);
        }
    }

    public class TheGetAllShotLikesMethod
    {
        [IntegrationTest(Skip = "Takes too long to run.")]
        public async Task ReturnsAllShotLikes()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var likes = await dribbble.User.Likes.GetAllShotLikes("simplebits");

            Assert.True(likes.Count >= 10);
        }
    }

    public class TheGetAllShotLikesForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllShotLikes()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var likes = await dribbble.User.Likes.GetAllShotLikesForCurrent();

            Assert.True(likes.Count >= 10);
        }
    }

    public class TheGetAllProjectsMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllProjects()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var projects = await dribbble.User.Projects.GetAllProjects("simplebits");

            Assert.True(projects.Count >= 5);
        }
    }

    public class TheGetAllProjectsForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllProjectsForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var projects = await dribbble.User.Projects.GetAllProjectsForCurrent();

            Assert.True(projects.Count >= 0);
        }
    }

    public class TheGetAllShotsMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllShots()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var shots = await dribbble.User.Shots.GetAllShots("simplebits");

            Assert.True(shots.Count >= 10);
        }
    }

    public class TheGetAllShotsForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllShotsForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var shots = await dribbble.User.Shots.GetAllShotsForCurrent();

            Assert.True(shots.Count >= 0);
        }
    }

    public class TheGetAllTeamsMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllTeams()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var teams = await dribbble.User.Teams.GetAllTeams("simplebits");

            Assert.True(teams.Count >= 1);
        }
    }

    public class TheGetAllTeamsForCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllTeamsForCurrent()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var teams = await dribbble.User.Teams.GetAllTeamsForCurrent();

            Assert.True(teams.Count >= 0);
        }
    }
}