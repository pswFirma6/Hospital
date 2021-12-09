using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IPatientService
    {
        Patient Register(Patient patient);
        bool CheckExisting(Patient patient);

        List<Patient> GetMaliciousPatients();
    }
}
