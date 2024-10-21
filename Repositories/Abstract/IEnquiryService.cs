using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for enquiry-related services.
    /// </summary>
    public interface IEnquiryService
    {
        /// <summary>
        /// Retrieves all enquiries for a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of enquiry view models.</returns>
        IEnumerable<EnquiryViewModel> GetAllEnquiries(int id);

        /// <summary>
        /// Retrieves past enquiries for a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of past enquiry view models.</returns>
        IEnumerable<EnquiryViewModel> GetPastEnquiries(int id);

        /// <summary>
        /// Retrieves enquiries made by a specific student.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>An enumerable collection of enquiry view models.</returns>
        IEnumerable<EnquiryViewModel> GetEnquiriesByStudent(int id);

        /// <summary>
        /// Retrieves past enquiries made by a specific student.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>An enumerable collection of past enquiry view models.</returns>
        IEnumerable<EnquiryViewModel> GetPastEnquiriesByStudent(int id);

        /// <summary>
        /// Retrieves the name of a course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>The name of the course as a string.</returns>
        string GetCourseName(int id);

        /// <summary>
        /// Retrieves detailed information about a specific enquiry by its ID.
        /// </summary>
        /// <param name="id">The ID of the enquiry.</param>
        /// <returns>The detailed enquiry view model.</returns>
        EnquiryViewModel GetDetailedEnquiry(int id);

        /// <summary>
        /// Retrieves an enquiry by its ID.
        /// </summary>
        /// <param name="id">The ID of the enquiry.</param>
        /// <returns>The enquiry object.</returns>
        Enquiry GetEnquiryById(int id);

        /// <summary>
        /// Creates a new enquiry.
        /// </summary>
        /// <param name="enquiry">The enquiry object to be created.</param>
        void CreateEnquiry(Enquiry enquiry);

        /// <summary>
        /// Updates an existing enquiry.
        /// </summary>
        /// <param name="enquiry">The enquiry object with updated information.</param>
        void UpdateEnquiry(Enquiry enquiry);

        /// <summary>
        /// Deletes an enquiry by its ID.
        /// </summary>
        /// <param name="id">The ID of the enquiry to be deleted.</param>
        void DeleteEnquiry(int id);
    }
}