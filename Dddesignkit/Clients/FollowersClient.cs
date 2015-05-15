using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Followers API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/followers/">Followers API documentation</a> for more information.
    ///</remarks>
    public class FollowersClient : ApiClient, IFollowersClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Followers API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public FollowersClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Get all followers of the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Follower}"/> of <see cref="Follower"/>.</returns>
        public Task<IReadOnlyList<Followers>> GetAllFollowers(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Followers>(ApiUrls.Followers(username));
        }

        /// <summary>
        /// Get all followers for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Follower}"/> of <see cref="Follower"/>.</returns>
        public Task<IReadOnlyList<Followers>> GetAllFollowersForCurrent()
        {
            return ApiConnection.GetAll<Followers>(ApiUrls.Followers());
        }

        /// <summary>
        /// Get all users followed by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Follower}"/> of <see cref="Follower"/>.</returns>
        public Task<IReadOnlyList<Following>> GetAllFollowing(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Following>(ApiUrls.Following(username));
        }

        /// <summary>
        /// Get all users followed by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Following}"/> of <see cref="Following"/>.</returns>
        public Task<IReadOnlyList<Following>> GetAllFollowingForCurrent()
        {
            return ApiConnection.GetAll<Following>(ApiUrls.Following());
        }

        /// <summary>
        /// Get all shots for users followed by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        public Task<IReadOnlyList<Shot>> GetAllShotsUsersFollowedForCurrent()
        {
            return ApiConnection.GetAll<Shot>(ApiUrls.ShotsUserFollowed());
        }

        /// <summary>
        /// Check if the authenticated user follows another user
        /// </summary>
        /// <param name="following">The username name of the other user</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#check-if-you-are-following-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        public async Task<bool> IsFollowingForCurrent(string following)
        {
            Ensure.ArgumentNotNullOrEmptyString(following, "following");

            try
            {
                var response = await Connection.Get<object>(ApiUrls.IsFollowing(following), null, null)
                                                .ConfigureAwait(false);
                return response.HttpResponse.IsTrue();
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if one user follows another user
        /// </summary>
        /// <param name="username">The username name of the user</param>
        /// <param name="following">The username name of the other user</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#check-if-one-user-is-following-another">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        public async Task<bool> IsFollowing(string username, string following)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");
            Ensure.ArgumentNotNullOrEmptyString(following, "following");

            try
            {
                var response = await Connection.Get<object>(ApiUrls.IsFollowing(username, following), null, null)
                                                .ConfigureAwait(false);
                return response.HttpResponse.IsTrue();
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Follow a user
        /// </summary>
        /// <param name="username">The username of the user to follow</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#follow-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        public async Task<bool> Follow(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            try
            {
                var requestData = new { };
                var response = await Connection.Put<object>(ApiUrls.Follow(username), requestData)
                                                .ConfigureAwait(false);
                if (response.HttpResponse.StatusCode != HttpStatusCode.NoContent)
                {
                    throw new ApiException("Invalid Status Code returned. Expected a 204", response.HttpResponse.StatusCode);
                }
                return response.HttpResponse.StatusCode == HttpStatusCode.NoContent;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Unfollow a user
        /// </summary>
        /// <param name="username">The username of the user to unfollow</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#unfollow-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns></returns>
        public Task Unfollow(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.Delete(ApiUrls.Follow(username));
        }
    }
}
