
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor GetOne(int id);
        List<Doctor> GetSpecialists(DoctorType type);
    }
}
