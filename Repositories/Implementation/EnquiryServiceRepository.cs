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
    public class EnquiryServiceRepository : IEnquiryService
    {
        private readonly AppDbContext _context;

        public EnquiryServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EnquiryViewModel> GetAllEnquiries(int id)
        {
            return _context.enquiryViewModels.FromSqlInterpolated($"dbo.sp_get_enquiriesbyUserId {id}").ToList();
        }
        public IEnumerable<EnquiryViewModel> GetPastEnquiries(int id)
        {
            return _context.enquiryViewModels.FromSqlInterpolated($"dbo.sp_get_past_enquiries {id}").ToList();
        }
        public EnquiryViewModel GetDetailedEnquiry(int id)
        {
            return _context.enquiryViewModels.FromSqlInterpolated($"dbo.sp_get_detailed_enquiry {id}").AsEnumerable().FirstOrDefault();
        }
        public Enquiry GetEnquiryById(int id)
        {
            return _context.Enquiries.Find(id);
        }

        public void CreateEnquiry(Enquiry enquiry)
        {
            _context.Enquiries.Add(enquiry);
            _context.SaveChanges();
        }

        public void UpdateEnquiry(Enquiry enquiry)
        {
            _context.Enquiries.Update(enquiry);
            _context.SaveChanges();
        }

        public void DeleteEnquiry(int id)
        {
            var enquiry = _context.Enquiries.Find(id);
            if (enquiry != null)
            {
                _context.Enquiries.Remove(enquiry);
                _context.SaveChanges();
            }
        }


    }
}