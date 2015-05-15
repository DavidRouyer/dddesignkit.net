using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
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

        /// <summary>
        /// Initializes a new Dribbble Users API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
            Buckets = new UserBucketsClient(apiConnection);
            Followers = new FollowersClient(apiConnection);
            Likes = new UserLikesClient(apiConnection);
            Projects = new UserProjectsClient(apiConnection);
            Shots = new UserShotsClient(apiConnection);
            Teams = new UserTeamsClient(apiConnection);
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
        /// A client for Dribbble's User Buckets API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/buckets/">Buckets API documentation</a> for more information.
        ///</remarks>
        public IUserBucketsClient Buckets { get; private set; }

        /// <summary>
        /// A client for Dribbble's User Followers API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/">Followers API documentation</a> for more information.
        ///</remarks>
        public IFollowersClient Followers { get; private set; }

        /// <summary>
        /// A client for Dribbble's User Likes API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/likes/">Likes API documentation</a> for more information.
        ///</remarks>
        public IUserLikesClient Likes { get; private set; }

        /// <summary>
        /// A client for Dribbble's User Projects API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/projects/">Projects API documentation</a> for more information.
        ///</remarks>
        public IUserProjectsClient Projects { get; private set; }

        /// <summary>
        /// A client for Dribbble's User Shots API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/shots/">Shots API documentation</a> for more information.
        ///</remarks>
        public IUserShotsClient Shots { get; private set; }

        /// <summary>
        /// A client for Dribbble's User Teams API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/teams/">Teams API documentation</a> for more information.
        ///</remarks>
        public IUserTeamsClient Teams { get; private set; }
    }
}
