using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_EduHub.Models;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Repositories.Implementation
{
    public class MaterialServiceRepository : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialServiceRepository(AppDbContext context)
        {
            _context = context;

        }


        public IEnumerable<Material> GetMaterialByCourseId(int id)
        {
            return _context.Materials
                  .Where(m => m.Courseid == id)
                 .ToList();
        }

        public void AddNewMaterial(int courseId, Material model)
        {
            var material = new Material
            {
                Courseid = courseId,
                Title = model.Title,
                Description = model.Description,
                Url = model.Url,
                UploadDate = model.UploadDate,
                ContentType = model.ContentType
            };

            _context.Materials.Add(material);
            _context.SaveChanges();
        }

    }
}