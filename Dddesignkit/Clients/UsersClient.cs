using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit.Clients
{
    /// <summary>
    /// A client for Dribbble's Users API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/">Users API documentation</a> for more information.
    /// </remarks>
    public class UsersClient : ApiClient, IUsersClient
    {
        static readonly Uri _userEndpoint = new Uri("user", UriKind.Relative);

        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Returns the user specified by the username.
        /// </summary>
        /// <param name="username">The username for the user</param>
        public Task<User> Get(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            var endpoint = "users/{0}".FormatUri(username);
            return ApiConnection.Get<User>(endpoint);
        }

        /// <summary>
        /// Returns a <see cref="User"/> for the current authenticated user.
        /// </summary>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        /// <returns>A <see cref="User"/></returns>
        public Task<User> Current()
        {
            return ApiConnection.Get<User>(_userEndpoint);
        }

        /// <summary>
        /// Get all shots owned by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        public Task<IReadOnlyList<Bucket>> GetAllBuckets(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Bucket>(ApiUrls.Buckets(username));
        }

        /// <summary>
        /// Get all shots owned by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        public Task<IReadOnlyList<Bucket>> GetAllBucketsForCurrent()
        {
            return ApiConnection.GetAll<Bucket>(ApiUrls.Buckets());
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
        /// Get all shot likes for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Like}"/> of <see cref="Like"/>.</returns>
        public Task<IReadOnlyList<Like>> GetAllShotLikes(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Like>(ApiUrls.ShotLikes(username));
        }

        /// <summary>
        /// Get all shot likes for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Like}"/> of <see cref="Like"/>.</returns>
        public Task<IReadOnlyList<Like>> GetAllShotLikesForCurrent()
        {
            return ApiConnection.GetAll<Like>(ApiUrls.ShotLikes());
        }

        /// <summary>
        /// Get all projects for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Project}"/> of <see cref="Project"/>.</returns>
        public Task<IReadOnlyList<Project>> GetAllProjects(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Project>(ApiUrls.Projects(username));
        }

        /// <summary>
        /// Get all projects for the current user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Project}"/> of <see cref="Project"/>.</returns>
        public Task<IReadOnlyList<Project>> GetAllProjectsForCurrent()
        {
            return ApiConnection.GetAll<Project>(ApiUrls.Projects());
        }

        /// <summary>
        /// Get all shots for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        public Task<IReadOnlyList<Shot>> GetAllShots(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Shot>(ApiUrls.Shots(username));
        }

        /// <summary>
        /// Get all shots for the current user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        public Task<IReadOnlyList<Shot>> GetAllShotsForCurrent()
        {
            return ApiConnection.GetAll<Shot>(ApiUrls.Shots());
        }
    }
}
