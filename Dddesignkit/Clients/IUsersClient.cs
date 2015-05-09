using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit.Clients
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
        /// Get all shots owned by the user.
        /// </summary>
        /// <typeparam name="IReadOnlyList"></typeparam>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<IReadOnlyList<Bucket>> GetAllBuckets(string username);
    }
}
