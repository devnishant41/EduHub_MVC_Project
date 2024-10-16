using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IUserService
    {
        User GetUserByUsernameAndPassword(string username, string password);
        string GetLoggedInUserName(int userId);
         string GetFullName(int userId);

        Task RegisterUser(SignupViewModel model, string profileImageFileName);

        string GetProfileImage (int id);

        ProfileViewModel GetUserProfile(int id);


    }
}