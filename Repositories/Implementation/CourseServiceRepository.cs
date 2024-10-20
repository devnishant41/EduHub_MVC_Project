using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_EduHub.Models;
using Test_EduHub.Models.Combined;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Repositories.Implementation
{
    public class CourseServiceRepository : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseServiceRepository(AppDbContext context)
        {
            _context = context;

        }

        public IEnumerable<Course> GetCoursesByUserId(int id)
        {
            Console.WriteLine($" id is {id}");

            var data = _context.Courses.Where(c => c.Userid == id).ToList();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Title}");

            }
            if (data == null)
            {
                throw new InvalidOperationException("Courses Not Found");
            }
            return data;
        }

        public Course GetCourseById(int id)
        {
            var course = _context.Courses.AsNoTracking().FirstOrDefault(c => c.Id == id);
            return course;
        }
        public IEnumerable<Course> GetAllCoursesList()
        {
            return _context.Courses.ToList();
        }

        public IEnumerable<AllCoursesViewModel> GetAllCourses()
        {
            return _context.AllCoursesViewModels.FromSqlInterpolated($"dbo.sp_Get_All_Courses").ToList();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }



        //educator
        public IEnumerable<AllCoursesViewModel> GetAllEducatorCoursesById(int id)
        {
            return _context.AllCoursesViewModels.FromSqlInterpolated($"dbo.sp_Get_All_Educator_Courses_By_Id {id}").ToList();
        }

        public IEnumerable<CourseDetailsViewModel> GetCourseDetailsById(int id)
        {
            return _context.courseDetailsViewModels.FromSqlInterpolated($"dbo.sp_Get_Course_Details_By_Id {id}").ToList();
        }

        public async Task<Course?> GetAllCourseDetailsById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course;
        }
        public async void EditCourse(Course course)
        {
            Console.WriteLine($"{course}");
            _context.Courses.Update(course);
            _context.SaveChangesAsync();

        }

        public async Task DeleteCourseAsync(int id)
        {
            try
            {
                Console.WriteLine($"Deleting course with ID: {id}");

                // Execute the stored procedure asynchronously
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.sp_delete_Course {id}");
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                Console.WriteLine($"An error occurred while deleting the course: {ex.Message}");
                // Consider logging the exception or rethrowing it
            }
        }



        //student get enrolled courses
        public IEnumerable<AllCoursesViewModel> GetEnrolledCoursesByStudentId(int id)
        {
            return _context.AllCoursesViewModels.FromSqlInterpolated($"dbo.sp_Get_Enrolled_Courses {id}").ToList();

        }


        public void CreateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public IEnumerable<CourseReviewModel> GetCourseReviews(int id)
        {
            return _context.courseReviewModels.FromSqlInterpolated($"dbo.sp_getReviewsByCourseId {id}").ToList();

        }
    }
}