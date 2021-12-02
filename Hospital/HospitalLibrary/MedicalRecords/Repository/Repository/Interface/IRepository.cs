using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class
    { 
        List<Entity> GetAll();
        Entity GetOne(string id);
        Entity Add(Entity newEntity);
        Entity Update(Entity updatedEntity);
    }
}
