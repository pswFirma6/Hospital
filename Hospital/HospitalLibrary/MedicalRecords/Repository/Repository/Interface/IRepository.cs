using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalRecords.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class
    { 
        List<Entity> GetAll();
        Entity GetOne(int id);
        Entity Add(Entity newEntity);
        Entity Update(Entity updatedEntity);
    }
}
