using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models;

namespace Test_EduHub.Repositories.Abstract
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetMaterialByCourseId(int id);

        Material GetMaterialByMaterialId(int id);

        void AddNewMaterial(int id,Material newMateial);

        Task UpdateMaterial (Material material);

        void DeleteMaterial (int id);
    }
}