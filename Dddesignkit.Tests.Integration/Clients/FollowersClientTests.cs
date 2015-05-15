using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FollowersClientTests/* : IDisposable*/
{
    /*[IntegrationTest]
    public async Task ChecksIfIsFollowingUserWhenFollowingUser()
    {
        var dribbble = Helper.GetAuthenticatedClient();

        await dribbble.User.Followers.Follow("kellyschmidt");

        var isFollowing = await dribbble.User.Followers.IsFollowingForCurrent("kellyschmidt");

        Assert.True(isFollowing);
    }

    [IntegrationTest]
    public async Task ChecksIfIsFollowingUserWhenNotFollowingUser()
    {
        var dribbble = Helper.GetAuthenticatedClient();

        var isFollowing = await dribbble.User.Followers.IsFollowingForCurrent("kellyschmidt");

        Assert.False(isFollowing);
    }

    [IntegrationTest]
    public async Task FollowUserNotBeingFollowedByTheUser()
    {
        var dribbble = Helper.GetAuthenticatedClient();

        var result = await dribbble.User.Followers.Follow("kellyschmidt");
        var following = await dribbble.User.Followers.GetAllFollowingForCurrent();

        Assert.True(result);
        Assert.NotEmpty(following);
        Assert.True(following.Any(f => f.Followee.Username == "kellyschmidt"));
    }

    [IntegrationTest]
    public async Task UnfollowUserBeingFollowedByTheUser()
    {
        var dribbble = Helper.GetAuthenticatedClient();

        await dribbble.User.Followers.Follow("kellyschmidt");
        var followers = await dribbble.User.Followers.GetAllFollowers("kellyschmidt");
        Assert.True(followers.Any(f => f.Follower.Username == _currentUser.Username));

        await dribbble.User.Followers.Unfollow("kellyschmidt");
        followers = await dribbble.User.Followers.GetAllFollowers("kellyschmidt");
        Assert.False(followers.Any(f => f.Follower.Username == _currentUser.Username));
    }

    [IntegrationTest]
    public async Task UnfollowUserNotBeingFollowedTheUser()
    {
        var dribbble = Helper.GetAuthenticatedClient();

        var followers = await dribbble.User.Followers.GetAllFollowers("kellyschmidt");
        Assert.False(followers.Any(f => f.Follower.Username == _currentUser.Username));

        await dribbble.User.Followers.Unfollow("kellyschmidt");
    }

    public void Dispose()
    {
        _dribbble.User.Followers.Unfollow("kellyschmidt");
    }*/
}
