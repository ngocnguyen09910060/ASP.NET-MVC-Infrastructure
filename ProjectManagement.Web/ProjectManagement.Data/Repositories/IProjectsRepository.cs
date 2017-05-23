using ProjectManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Repositories
{
    /// <summary>
    /// Project repository.
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// Get project by id.
        /// </summary>
        /// <param name="id">Project id.</param>
        /// <returns></returns>
        Project GetProjectById(int id);

        /// <summary>
        /// Create project.
        /// </summary>
        /// <param name="project">Project model.</param>
        /// <returns></returns>
        int? CreateProject(Project project);

        /// <summary>
        /// Update project.
        /// </summary>
        /// <param name="project">Project model.</param>
        void UpdateProject(Project project);

        /// <summary>
        /// Delete project.
        /// </summary>
        /// <param name="id">Project id.</param>
        void DeleteProject(int id);
    }
}
