using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUserBucketsClient
    {
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
    }
}
