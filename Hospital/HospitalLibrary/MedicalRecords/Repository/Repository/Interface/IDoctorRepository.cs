
using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
    }
}
