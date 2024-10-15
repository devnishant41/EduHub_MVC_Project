using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IEnrollmentService
    {
        // IEnumerable<Enrollment> GetAllEnrollments();
        // Enrollment GetEnrollmentById(int id);
        void AddEnrollment(Enrollment enrollment);
        // void UpdateEnrollment(Enrollment enrollment);
        // void DeleteEnrollment(int id);
    }
}