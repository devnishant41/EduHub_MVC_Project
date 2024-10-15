using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Repositories.Implementation
{
    public class EnrollmentServiceRepository : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        // public IEnumerable<Enrollment> GetAllEnrollments()
        // {
        //     return _context.Enrollments.ToList();
        // }

        // public Enrollment GetEnrollmentById(int id)
        // {
        //     return _context.Enrollments.Find(id) ;
        // }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        // public void UpdateEnrollment(Enrollment enrollment)
        // {
        //     _context.Enrollments.Update(enrollment);
        //     _context.SaveChanges();
        // }

        // public void DeleteEnrollment(int id)
        // {
        //     var enrollment = _context.Enrollments.Find(id);
        //     if (enrollment != null)
        //     {
        //         _context.Enrollments.Remove(enrollment);
        //         _context.SaveChanges();
        //     }
        // }

       
    }
}