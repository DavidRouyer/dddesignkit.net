using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit.Clients
{
    public interface IShotsClient
    {
        /// <summary>
        /// Get all shots
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Shot}"/> of <see cref="Shot"/>.</returns>
        Task<IReadOnlyList<Shot>> GetAll();

        /// <summary>
        /// Returns the shot specified by the id.
        /// </summary>
        /// <param name="id">The id for the shot</param>
        Task<Shot> Get(int id);
    }
}
