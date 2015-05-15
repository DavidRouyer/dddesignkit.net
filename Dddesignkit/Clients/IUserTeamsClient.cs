using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUserTeamsClient
    {
        /// <summary>
        /// Get all teams for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Team}"/> of <see cref="Team"/>.</returns>
        Task<IReadOnlyList<Team>> GetAllTeams(string username);

        /// <summary>
        /// Get all teams for the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Team}"/> of <see cref="Team"/>.</returns>
        Task<IReadOnlyList<Team>> GetAllTeamsForCurrent();
    }
}
