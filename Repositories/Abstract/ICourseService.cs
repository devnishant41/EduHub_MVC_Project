using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Combined;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for course-related services.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Retrieves a list of courses associated with a specific user ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An enumerable collection of courses.</returns>
        IEnumerable<Course> GetCoursesByUserId(int id);

        /// <summary>
        /// Retrieves all available categories.
        /// </summary>
        /// <returns>An enumerable collection of categories.</returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Retrieves all courses in a combined view model.
        /// </summary>
        /// <returns>An enumerable collection of all courses view models.</returns>
        IEnumerable<AllCoursesViewModel> GetAllCourses();

        /// <summary>
        /// Retrieves a list of all courses.
        /// </summary>
        /// <returns>An enumerable collection of courses.</returns>
        IEnumerable<Course> GetAllCoursesList();

        /// <summary>
        /// Retrieves a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>The course object.</returns>
        Course GetCourseById(int id);

        /// <summary>
        /// Adds a new course.
        /// </summary>
        /// <param name="course">The course object to be added.</param>
        void AddCourse(Course course);

        // Educator-related methods

        /// <summary>
        /// Retrieves all courses taught by a specific educator.
        /// </summary>
        /// <param name="id">The ID of the educator.</param>
        /// <returns>An enumerable collection of all courses view models.</returns>
        IEnumerable<AllCoursesViewModel> GetAllEducatorCoursesById(int id);

        /// <summary>
        /// Retrieves detailed information about a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of course details view models.</returns>
        IEnumerable<CourseDetailsViewModel> GetCourseDetailsById(int id);

        /// <summary>
        /// Asynchronously retrieves all details for a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>A task representing the asynchronous operation, containing the course object or null.</returns>
        Task<Course?> GetAllCourseDetailsById(int id);

        /// <summary>
        /// Edits an existing course.
        /// </summary>
        /// <param name="course">The course object with updated information.</param>
        void EditCourse(Course course);

        /// <summary>
        /// Asynchronously deletes a course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to be deleted.</param>
        Task DeleteCourseAsync(int id);

        // Student-related methods

        /// <summary>
        /// Retrieves all courses a student is enrolled in by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>An enumerable collection of all courses view models.</returns>
        IEnumerable<AllCoursesViewModel> GetEnrolledCoursesByStudentId(int id);

        /// <summary>
        /// Retrieves reviews for a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of course review models.</returns>
        IEnumerable<CourseReviewModel> GetCourseReviews(int id);
    }
}