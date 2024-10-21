using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.Domain.Enrollments;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for enrollment-related services.
    /// </summary>
    public interface IEnrollmentService
    {
        /// <summary>
        /// Retrieves all enrollments for a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An enumerable collection of enrollment view models.</returns>
        IEnumerable<EnrollmentViewModel> GetAllEnrollmentsByUserId(int id);

        /// <summary>
        /// Retrieves a specific enrollment by its ID.
        /// </summary>
        /// <param name="id">The ID of the enrollment.</param>
        /// <returns>The enrollment object.</returns>
        Enrollment GetEnrollmentById(int id);

        /// <summary>
        /// Updates the status of an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to be updated.</param>
        /// <param name="status">The new status to set for the enrollment.</param>
        void UpdateEnrollment(int id, string status);

        /// <summary>
        /// Creates a new enrollment.
        /// </summary>
        /// <param name="enrollment">The enrollment object to be created.</param>
        void CreateEnrollment(Enrollment enrollment);

        /// <summary>
        /// Retrieves previous enrollment records for a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An enumerable collection of previous enrollment models.</returns>
        IEnumerable<PreviousEnrollmentModel> GetPreviousEnrollment(int id);
    }
}