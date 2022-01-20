using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
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
        Patient GetByLoginCredentials(string username, string password, UserType userType);
        Patient GetByUsername(string username);
        void SetPatientMaliciousStatus(int id, bool status);
    }
}
