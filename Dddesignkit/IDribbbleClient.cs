using Dddesignkit.Clients;
namespace Dddesignkit
{
    /// <summary>
    /// A client for the Dribbble API v1. You can read more about the api here : http://developer.dribbble.com/v1
    /// </summary>
    public interface IDribbbleClient
    {
        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Access Dribbble's Users API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: https://developer.dribbble.com/v1/users/
        /// </remarks>
        IUsersClient User { get; }

        /// <summary>
        /// Access Dribbble's Shots API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: https://developer.dribbble.com/v1/shots/
        /// </remarks>
        IShotsClient Shots { get; }
    }
}