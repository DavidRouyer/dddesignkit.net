using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Teams API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/teams/">Teams API documentation</a> for more information.
    ///</remarks>
    public class UserTeamsClient : ApiClient, IUserTeamsClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Teams API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UserTeamsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Get all teams for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Team}"/> of <see cref="Team"/>.</returns>
        public Task<IReadOnlyList<Team>> GetAllTeams(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Team>(ApiUrls.Teams(username));
        }

        /// <summary>
        /// Get all teams for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Team}"/> of <see cref="Team"/>.</returns>
        public Task<IReadOnlyList<Team>> GetAllTeamsForCurrent()
        {
            return ApiConnection.GetAll<Team>(ApiUrls.Teams());
        }
    }
}
