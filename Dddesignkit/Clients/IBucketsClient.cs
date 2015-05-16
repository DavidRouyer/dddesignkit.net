using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IBucketsClient
    {
        /// <summary>
        /// Returns the bucket specified by the id.
        /// </summary>
        /// <param name="id">The id for the bucket</param>
        Task<Bucket> Get(int id);
    }
}
