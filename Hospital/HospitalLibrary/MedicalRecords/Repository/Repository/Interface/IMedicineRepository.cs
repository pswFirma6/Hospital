using Hospital_library.MedicalRecords.Model;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IMedicineRepository
    {
        Medicine Add(Medicine medicine);
        List<Medicine> GetAll();
        Medicine GetOne(int id);
        Medicine Update(Medicine medicine);
    }
}
