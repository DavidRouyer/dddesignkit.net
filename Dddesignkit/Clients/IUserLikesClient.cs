using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUserLikesClient
    {
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
    }
}
