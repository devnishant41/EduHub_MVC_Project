using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Repositories.Abstract
{
    /// <summary>
    /// Interface for user-related services.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a user by their username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        User GetUserByUsernameAndPassword(string username, string password);

        /// <summary>
        /// Retrieves the logged-in user's name by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The username of the logged-in user.</returns>
        string GetLoggedInUserName(int userId);

        /// <summary>
        /// Retrieves the full name of a user by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The full name of the user.</returns>
        string GetFullName(int userId);

        /// <summary>
        /// Registers a new user with the provided signup model and profile image filename.
        /// </summary>
        /// <param name="model">The signup view model containing user information.</param>
        /// <param name="profileImageFileName">The filename of the user's profile image.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RegisterUser (SignupViewModel model, string profileImageFileName);

        /// <summary>
        /// Retrieves the profile image filename of a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The filename of the user's profile image.</returns>
        string GetProfileImage(int id);

        /// <summary>
        /// Retrieves the user profile information by user ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The profile view model of the user.</returns>
        ProfileViewModel GetUserProfile(int id);
    }
}