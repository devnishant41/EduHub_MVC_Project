using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.DTO;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IEnquiryService
    {

        IEnumerable<EnquiryViewModel> GetAllEnquiries(int id);
        IEnumerable<EnquiryViewModel> GetPastEnquiries(int id);
        IEnumerable<EnquiryViewModel> GetEnquiriesByStudent(int id);
        IEnumerable<EnquiryViewModel> GetPastEnquiriesByStudent(int id);
        string GetCourseName(int id);

        EnquiryViewModel GetDetailedEnquiry(int id);
        Enquiry GetEnquiryById(int id);
        void CreateEnquiry(Enquiry enquiry);
        void UpdateEnquiry(Enquiry enquiry);
        void DeleteEnquiry(int id);
    }
}