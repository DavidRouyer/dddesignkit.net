using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IProjectsClient
    {
        /// <summary>
        /// Returns the project specified by the id.
        /// </summary>
        /// <param name="id">The id for the project</param>
        Task<Project> Get(int id);
    }
}
