using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for material-related services.
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// Retrieves materials associated with a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of materials.</returns>
        IEnumerable<Material> GetMaterialByCourseId(int id);

        /// <summary>
        /// Retrieves a specific material by its ID.
        /// </summary>
        /// <param name="id">The ID of the material.</param>
        /// <returns>The material object.</returns>
        Material GetMaterialByMaterialId(int id);

        /// <summary>
        /// Adds a new material associated with a specific course.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <param name="newMaterial">The new material object to be added.</param>
        void AddNewMaterial(int id, Material newMaterial);

        /// <summary>
        /// Asynchronously updates an existing material.
        /// </summary>
        /// <param name="material">The material object with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateMaterial(Material material);

        /// <summary>
        /// Deletes a material by its ID.
        /// </summary>
        /// <param name="id">The ID of the material to be deleted.</param>
        void DeleteMaterial(int id);
    }
}