using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IFollowersClient
    {
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
        /// Check if the authenticated user follows another user
        /// </summary>
        /// <param name="following">The username name of the other user</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#check-if-you-are-following-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        Task<bool> IsFollowingForCurrent(string following);

        /// <summary>
        /// Check if one user follows another user
        /// </summary>
        /// <param name="username">The username name of the user</param>
        /// <param name="following">The username name of the other user</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#check-if-one-user-is-following-another">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        Task<bool> IsFollowing(string username, string following);

        /// <summary>
        /// Follow a user
        /// </summary>
        /// <param name="username">The username of the user to follow</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#follow-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns>A <c>bool</c> representing the success of the operation.</returns>
        Task<bool> Follow(string username);

        /// <summary>
        /// Unfollow a user
        /// </summary>
        /// <param name="username">The username of the user to unfollow</param>
        /// <remarks>
        /// See the <a href="http://developer.dribbble.com/v1/users/followers/#unfollow-a-user">API documentation</a> for more information.
        /// </remarks>
        /// <returns></returns>
        Task Unfollow(string username);
    }
}
