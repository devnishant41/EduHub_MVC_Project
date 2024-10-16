using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Repositories.Implementation
{
    public class FeedbackServiceRepository : IFeedbackService
    {

        private readonly AppDbContext _context;

        public FeedbackServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddFeedback(FeedbackModel feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public IEnumerable<AllFeedbackModel> GetAllFeedbacksByUserId(int id)
        {
            return _context.allFeedbackModels.FromSqlInterpolated($"dbo.sp_get_feedbackByUserIdWithCount_1 {id}").ToList();
        }
        public IEnumerable<DetailedFeedbackModel> GetListOfFeedbackByCourseId(int id)
        {
            return _context.detailedFeedbackModels.FromSqlInterpolated($"dbo.sp_get_feedbackByCourseId_1 {id}").ToList();
        }

        public FeedbackModel GetFeedbackById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

         public async Task SubmitFeedback(FeedbackModel feedback)
        {
        
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }



        public void DeleteFeedback(int id)
        {
            var feedback = GetFeedbackById(id);
            if (feedback != null)
            {
                feedback.IsActive = false; // Set IsActive to false
                _context.SaveChanges();
            }
        }
    }
}