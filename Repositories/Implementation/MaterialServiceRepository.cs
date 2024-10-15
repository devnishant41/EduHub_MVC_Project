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
            return _context.Materials.AsNoTracking()
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

        public async Task UpdateMaterial(Material material)
        {
            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
        }

        public void  DeleteMaterial(int id)
        {
            var material =  GetMaterialByMaterialId(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                 _context.SaveChangesAsync();
            }
        }

        public Material GetMaterialByMaterialId(int id)
        {
            return _context.Materials.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}