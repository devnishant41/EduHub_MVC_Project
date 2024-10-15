using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.DTO
{
  public class Enquiry
    {
        [Key]
        public int EnquiryId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(255)]
        public string Subject { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        [Required]
        public DateTime EnquiryDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        [StringLength(255)]
        public string? Response { get; set; }

        public override string ToString()
{
    return $"EnquiryId: {EnquiryId}\n" + 
           $"UserId: {UserId}\n" + 
           $"CourseId: {CourseId}\n" + 
           $"Subject: {Subject}\n" + 
           $"Message: {Message}\n" + 
           $"EnquiryDate: {EnquiryDate}\n" + 
           $"Status: {Status}\n" + 
           $"Response: {Response}";
}
    }
}
