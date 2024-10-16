using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class ProfileViewModel
    {

    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string ProfileImage { get; set; }
    public string Role { get; set; }
    public bool AccountStatus { get; set; }
    public bool ProfileCompleted { get; set; }
  
}
    }
