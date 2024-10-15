using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models.DTO;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{

    public class EnquiryController : Controller
    {
        private readonly IEnquiryService _enquiryService;

        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        // GET: Enquiries
        [Route("educator/enquiries")]
        [HttpGet]
        public IActionResult GetAllEnquiries()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var enquiries = _enquiryService.GetAllEnquiries(userId);
            return View(enquiries);
        }
        
        [Route("educator/enquiries/pastenquiries")]
        [HttpGet]
        public IActionResult GetPastEnquiries()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var enquiries = _enquiryService.GetPastEnquiries(userId);
            return View(enquiries);
        }

        [HttpGet]
        [Route("educator/enquiries/{id}")]
        public IActionResult ViewDetailedEnquiry(int id)
        {
            var enquiries = _enquiryService.GetDetailedEnquiry(id);
            return View(enquiries);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("educator/enquiries/{id}")]
        public IActionResult ViewDetailedEnquiry(int id, Enquiry enquiry)
        {   
             var enquiries = _enquiryService.GetEnquiryById(id);
            //  enquiry.EnquiryDate = enquiries.EnquiryDate;
            //  enquiry.EnquiryId = enquiries.EnquiryId;
             enquiries.Status = "Closed";
             enquiries.Response = enquiry.Response;

             Console.WriteLine($"{enquiries}");
             Console.WriteLine($"{enquiry}");
             
            
            if (id != enquiries.EnquiryId)
            {   System.Console.WriteLine("in nto found");
                return NotFound();
            }

            // if (ModelState.IsValid)
            // {
                _enquiryService.UpdateEnquiry(enquiries);
            // }
            // return View(enquiries);
            return RedirectToAction(nameof(GetAllEnquiries));
        }




        // GET: Enquiries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enquiries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,CourseId,Subject,Message,EnquiryDate,Status,Response")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                _enquiryService.CreateEnquiry(enquiry);
                return RedirectToAction(nameof(Index));
            }
            return View(enquiry);
        }

        // GET: Enquiries/Edit/5
        public IActionResult Edit(int id)
        {
            var enquiry = _enquiryService.GetEnquiryById(id);
            return View(enquiry);
        }


        

        // POST: Enquiries/Edit/5
       

        // GET: Enquiries/Delete/5
        public IActionResult Delete(int id)
        {
            var enquiry = _enquiryService.GetEnquiryById(id);
            return View(enquiry);
        }

        // POST: Enquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _enquiryService.DeleteEnquiry(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
