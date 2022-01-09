using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IPatientService
    {
        Patient Register(Patient patient);
        bool CheckExisting(Patient patient);
        Patient GetPatient(int id);
        public List<Patient> GetMaliciousPatients();
        public void BlockPatient(Patient patient);
        public void UnblockPatient(Patient patient);
        public Patient GetPatientByUsername(string username);

    }
}
