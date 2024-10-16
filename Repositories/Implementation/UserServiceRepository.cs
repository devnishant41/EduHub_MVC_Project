using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Repositories.Implementation
{
    public class UserServiceRepository : IUserService
    {
        private readonly AppDbContext _context;

        public UserServiceRepository(AppDbContext context)
        {
            _context = context;
        }


        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            // if (user == null)
            // {   
            //     throw new InvalidOperationException("User Not Found");
            // }
            return user;
        }

        public string GetLoggedInUserName(int userId)
        {
            var firstName = _context.Profiles.Where(u => u.UserId == userId).FirstOrDefault().Firstname;
            if (firstName == null)
            {
                return "User";
            }

            return firstName;
        }
        public string GetFullName(int userId)
        {
            var firstName = _context.Profiles.Where(u => u.UserId == userId).FirstOrDefault().Firstname;
            var LastName = _context.Profiles.Where(u => u.UserId == userId).FirstOrDefault().Lastname;
            if (firstName == null)
            {
                return "User";
            }

            return firstName + " " + LastName;
        }

        public async Task RegisterUser(SignupViewModel model, string profileImageFileName)
        {
            var sql = "EXEC sp_InsertUserProfile @Username, @Password, @Role, @FirstName, @LastName, @Email,@mobileNumber, @ProfileImage";
            await _context.Database.ExecuteSqlRawAsync(
                sql,
                new SqlParameter("@Username", model.Username),
                new SqlParameter("@Password", model.Password),
                new SqlParameter("@Role", model.Role),
                new SqlParameter("@FirstName", model.Firstname),
                new SqlParameter("@LastName", model.Lastname),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@mobileNumber", model.MobileNumber),
                new SqlParameter("@ProfileImage", profileImageFileName)
            );
        }

        public string GetProfileImage(int id)
        {
            return _context.Profiles.FirstOrDefault(x => x.UserId == id).ProfileImage;
        }


        public ProfileViewModel GetUserProfile(int id)
        {
              return _context.profileViewModels.FromSqlInterpolated($"dbo.sp_GetUserProfile {id}").AsEnumerable().FirstOrDefault();
        }
    }
}