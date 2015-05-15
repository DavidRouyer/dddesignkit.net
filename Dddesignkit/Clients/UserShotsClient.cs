using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Shots API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/shots/">Shots API documentation</a> for more information.
    ///</remarks>
    public class UserShotsClient : ApiClient, IUserShotsClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Shots API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UserShotsClient(IApiConnection apiConnection) : base(apiConnection)
        {
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
