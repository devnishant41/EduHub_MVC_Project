using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Test_EduHub.Models.Combined;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.Domain.Enrollments;
using Test_EduHub.Models.DTO;

namespace Test_EduHub.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Enquiry> Enquiries { get; set; } = null!;
        public virtual DbSet<FeedbackModel> Feedbacks { get; set; } = null!;

        //proc
        public DbSet<AllCoursesViewModel> AllCoursesViewModels {get;set;}
        public DbSet<CourseDetailsViewModel> courseDetailsViewModels {get;set;}
        public DbSet<EnrollmentViewModel> enrollmentViewModels {get;set;}
        public DbSet<EnquiryViewModel> enquiryViewModels {get;set;}
        public DbSet<AllFeedbackModel> allFeedbackModels {get;set;}
        public DbSet<DetailedFeedbackModel> detailedFeedbackModels {get;set;}
        public DbSet<PreviousEnrollmentModel> previousEnrollmentModels {get;set;}
        public DbSet<ProfileViewModel> profileViewModels {get;set;}
        public DbSet<CourseReviewModel> courseReviewModels {get;set;}

    }
}
