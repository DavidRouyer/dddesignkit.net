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
        /// <returns>A <see cref="IReadOnlyList{Bucket}"/> of <see cref="Bucket"/>.</returns>
        public Task<IReadOnlyList<Bucket>> GetAllBuckets(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Bucket>(ApiUrls.Buckets(username));
        }
    }
}
