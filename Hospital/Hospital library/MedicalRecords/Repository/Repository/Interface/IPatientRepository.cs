using Hospital_library.MedicalRecords.Model;
using System.Collections.Generic;


namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IPatientRepository
    {
        Patient GetByUniqueFields(string username, string email, string jmbg);
        Patient Add(Patient patient);
        List<Patient> GetAll();
    }
}
