using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}