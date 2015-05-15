using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Projects API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/projects/">Projects API documentation</a> for more information.
    ///</remarks>
    public class UserProjectsClient : ApiClient, IUserProjectsClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Projects API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UserProjectsClient(IApiConnection apiConnection) : base(apiConnection)
        {
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
    }
}
