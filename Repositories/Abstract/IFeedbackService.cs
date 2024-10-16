using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IFeedbackService
    {

        void AddFeedback(FeedbackModel feedback);
        IEnumerable<AllFeedbackModel> GetAllFeedbacksByUserId(int id);
        IEnumerable<DetailedFeedbackModel> GetListOfFeedbackByCourseId(int id);
        FeedbackModel GetFeedbackById(int id);
        void DeleteFeedback(int id);
        Task SubmitFeedback(FeedbackModel feedback);


    }
}