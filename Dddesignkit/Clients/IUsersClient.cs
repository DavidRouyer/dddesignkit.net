using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUsersClient
    {
        /// <summary>
        /// Returns the user specified by the username.
        /// </summary>
        /// <param name="username">The username for the user</param>
        Task<User> Get(string username);

        /// <summary>
        /// Returns a <see cref="User"/> for the current authenticated user.
        /// </summary>
        /// <exception cref="AuthorizationException">Thrown if the client is not authenticated.</exception>
        /// <returns>A <see cref="User"/></returns>
        Task<User> Current();

        /// <summary>
        /// A client for Dribbble's User Buckets API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/buckets/">Buckets API documentation</a> for more information.
        ///</remarks>
        IUserBucketsClient Buckets { get; }

        /// <summary>
        /// A client for Dribbble's User Followers API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/">Followers API documentation</a> for more information.
        ///</remarks>
        IFollowersClient Followers { get; }

        /// <summary>
        /// A client for Dribbble's User Likes API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/likes/">Likes API documentation</a> for more information.
        ///</remarks>
        IUserLikesClient Likes { get; }

        /// <summary>
        /// A client for Dribbble's User Projects API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/projects/">Projects API documentation</a> for more information.
        ///</remarks>
        IUserProjectsClient Projects { get; }

        /// <summary>
        /// A client for Dribbble's User Shots API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/shots/">Shots API documentation</a> for more information.
        ///</remarks>
        IUserShotsClient Shots { get; }

        /// <summary>
        /// A client for Dribbble's User Teams API
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/teams/">Teams API documentation</a> for more information.
        ///</remarks>
        IUserTeamsClient Teams { get; }
    }
}
