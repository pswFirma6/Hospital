using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;


namespace HospitalLibrary.MedicalRecords.Repository.Repository.Interface
{
    public interface IPatientRepository
    {
        Patient Add(Patient patient);
        List<Patient> GetAll();
        Patient GetOne(int id);
        Patient Update(Patient patient);
        Patient GetByEmail(string email);
        Patient GetOne(int id);
    }
}
