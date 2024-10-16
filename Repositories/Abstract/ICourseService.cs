using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Repositories.Abstract
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCoursesByUserId(int id);
        IEnumerable<Category> GetAllCategories();

        IEnumerable<AllCoursesViewModel> GetAllCourses();
        IEnumerable<Course> GetAllCoursesList();
        Course GetCourseById(int id);

        void AddCourse(Course course);

        //get educator courses

        IEnumerable<AllCoursesViewModel> GetAllEducatorCoursesById(int id);
        IEnumerable<CourseDetailsViewModel> GetCourseDetailsById(int id);
        Task<Course?> GetAllCourseDetailsById(int id);

        void EditCourse (Course course);

        Task DeleteCourseAsync (int id);


        // student
        IEnumerable<AllCoursesViewModel> GetEnrolledCoursesByStudentId(int id);


    }
}