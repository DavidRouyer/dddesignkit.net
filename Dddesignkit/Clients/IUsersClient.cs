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
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        Task<IReadOnlyList<Bucket>> GetAllBuckets(string username);

        /// <summary>
        /// Get all shots owned by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        Task<IReadOnlyList<Bucket>> GetAllBucketsForCurrent();

        /// <summary>
        /// Get all followers of the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Follower}"/> of <see cref="Follower"/>.</returns>
        Task<IReadOnlyList<Followers>> GetAllFollowers(string username);

        /// <summary>
        /// Get all followers for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Follower}"/> of <see cref="Follower"/>.</returns>
        Task<IReadOnlyList<Followers>> GetAllFollowersForCurrent();

        /// <summary>
        /// Get all users followed by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Following}"/> of <see cref="Following"/>.</returns>
        Task<IReadOnlyList<Following>> GetAllFollowing(string username);

        /// <summary>
        /// Get all users followed by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Following}"/> of <see cref="Following"/>.</returns>
        Task<IReadOnlyList<Following>> GetAllFollowingForCurrent();

        /// <summary>
        /// Get all shots for users followed by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Following}"/> of <see cref="Following"/>.</returns>
        Task<IReadOnlyList<Shot>> GetAllShotsUsersFollowedForCurrent();

        /// <summary>
        /// Get all shot likes for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Like}"/> of <see cref="Like"/>.</returns>
        Task<IReadOnlyList<Like>> GetAllShotLikes(string username);

        /// <summary>
        /// Get all shot likes for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Like}"/> of <see cref="Like"/>.</returns>
        Task<IReadOnlyList<Like>> GetAllShotLikesForCurrent();

        /// <summary>
        /// Get all projects for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Project}"/> of <see cref="Project"/>.</returns>
        Task<IReadOnlyList<Project>> GetAllProjects(string username);

        /// <summary>
        /// Get all projects for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Project}"/> of <see cref="Project"/>.</returns>
        Task<IReadOnlyList<Project>> GetAllProjectsForCurrent();

        /// <summary>
        /// Get all shots for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        Task<IReadOnlyList<Shot>> GetAllShots(string username);

        /// <summary>
        /// Get all shots for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        Task<IReadOnlyList<Shot>> GetAllShotsForCurrent();
    }
}
