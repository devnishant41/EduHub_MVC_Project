using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.Domain.Enrollments;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IEnrollmentService
    {
        // Enrollment GetEnrollmentById(int id);
        IEnumerable<EnrollmentViewModel> GetAllEnrollmentsByUserId(int id);
        void AddEnrollment(Enrollment enrollment);
        Enrollment GetEnrollmentById(int id);

        void UpdateEnrollment(int id,string  status);
        // void UpdateEnrollment(Enrollment enrollment);
        // void DeleteEnrollment(int id);
    }
}