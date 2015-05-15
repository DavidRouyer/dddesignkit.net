using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUserShotsClient
    {
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
