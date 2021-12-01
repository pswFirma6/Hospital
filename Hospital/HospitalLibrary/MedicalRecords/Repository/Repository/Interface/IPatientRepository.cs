using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;


namespace HospitalLibrary.MedicalRecords.Repository.Repository.Interface
{
    public interface IPatientRepository
    {
        Patient GetByUniqueFields(string username, string email, string jmbg);
        Patient Add(Patient patient);
        List<Patient> GetAll();
        Patient Update(Patient patient);
        Patient GetByEmail(string email);
    }
}
