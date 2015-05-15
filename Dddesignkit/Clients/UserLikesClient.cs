using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Likes API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/likes/">Likes API documentation</a> for more information.
    ///</remarks>
    public class UserLikesClient : ApiClient, IUserLikesClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Likes API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UserLikesClient(IApiConnection apiConnection) : base(apiConnection)
        {
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
    }
}
