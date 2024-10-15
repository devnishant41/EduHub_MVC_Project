using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class SignupViewModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public string Firstname { get; set; } = null!;

        [Required]
        public string Lastname { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;

        [Phone]
        public string? MobileNumber { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}