using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class
    { 
        List<Entity> GetAll();
        Entity GetOne(string id);
        Entity Add(Entity newEntity);
        Entity Update(Entity updatedEntity);
    }
}
