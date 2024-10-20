using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackRepository;

        private readonly ICourseService _courseservice;
        private readonly IEnquiryService _enquiryService;

        public FeedbackController(IFeedbackService feedbackRepository, ICourseService courseService, IEnquiryService enquiryService)
        {
            _feedbackRepository = feedbackRepository;
            _courseservice = courseService;
            _enquiryService = enquiryService;
        }

        [Route("educator/myfeedbacks")]
        public IActionResult GetEducatorFeedbacks()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var feedbacks = _feedbackRepository.GetAllFeedbacksByUserId(userId);
            return View(feedbacks);
        }


        [Route("educator/myfeedbacks/all/{id}")]
        public IActionResult DetailedFeedback(int id)
        {
            // int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var feedbacks = _feedbackRepository.GetListOfFeedbackByCourseId(id);
            return View(feedbacks);
        }

        public IActionResult DeleteFeedback(int id)
        {
            var feedback = _feedbackRepository.GetFeedbackById(id);
            return View(feedback);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFeedback(int id, FeedbackModel feedback)
        {
            _feedbackRepository.DeleteFeedback(id);
            return RedirectToAction(nameof(DetailedFeedback));
        }

        [HttpGet]
        [Route("student/course/mycourse/feedback/{id}")]
        public IActionResult SubmitFeedback(int id)
        {

            string name = _enquiryService.GetCourseName(id);
            ViewBag.CourseName = name;
            SubmitFeedbackModel model = new SubmitFeedbackModel()
            {
                CourseId = id,
            };
            return View(model);
        }

        [HttpPost]
        [Route("student/course/mycourse/feedback/{id}")]
        public async Task<IActionResult> SubmitFeedback(SubmitFeedbackModel feedbackmodel)
        {
            try
            {
                Console.WriteLine($"CourseId {feedbackmodel.CourseId}");
                Console.WriteLine($"Feedback {feedbackmodel.Feedback}");
                var newFeedback = new FeedbackModel
                {
                    UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                    CourseId = feedbackmodel.CourseId,
                    Feedback = feedbackmodel.Feedback,
                    Date = DateTime.UtcNow,
                    IsActive = true
                };
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Model state is not valid.");
                    return View("SubmitFeedback", feedbackmodel);
                }

                TempData["SuccessMessage"] = "Feedback Submitted Successfully!";
                await _feedbackRepository.SubmitFeedback(newFeedback);
                return RedirectToAction("CourseDetails", "Course", new { id = feedbackmodel.CourseId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while submitting feedback.";
                return View("SubmitFeedback", feedbackmodel);
            }
        }


    }
}