using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Material
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public string ContentType { get; set; } = null!;
        public int Courseid { get; set; }

        
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Description: {Description}, Url: {Url}, UploadDate: {UploadDate}, ContentType: {ContentType}, CourseId: {Courseid}";
    }

    }
}
