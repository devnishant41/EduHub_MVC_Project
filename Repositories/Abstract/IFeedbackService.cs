using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for feedback-related services.
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// Adds new feedback.
        /// </summary>
        /// <param name="feedback">The feedback model to be added.</param>
        void AddFeedback(FeedbackModel feedback);

        /// <summary>
        /// Retrieves all feedbacks submitted by a specific user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An enumerable collection of feedback models.</returns>
        IEnumerable<AllFeedbackModel> GetAllFeedbacksByUserId(int id);

        /// <summary>
        /// Retrieves a list of feedback for a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>An enumerable collection of detailed feedback models.</returns>
        IEnumerable<DetailedFeedbackModel> GetListOfFeedbackByCourseId(int id);

        /// <summary>
        /// Retrieves a specific feedback by its ID.
        /// </summary>
        /// <param name="id">The ID of the feedback.</param>
        /// <returns>The feedback model.</returns>
        FeedbackModel GetFeedbackById(int id);

        /// <summary>
        /// Deletes feedback by its ID.
        /// </summary>
        /// <param name="id">The ID of the feedback to be deleted.</param>
        void DeleteFeedback(int id);

        /// <summary>
        /// Asynchronously submits feedback.
        /// </summary>
        /// <param name="feedback">The feedback model to be submitted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SubmitFeedback(FeedbackModel feedback);
    }
}