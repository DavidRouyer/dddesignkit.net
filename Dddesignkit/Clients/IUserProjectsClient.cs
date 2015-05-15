using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface IUserProjectsClient
    {
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
    }
}
