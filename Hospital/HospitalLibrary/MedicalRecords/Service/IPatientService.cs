using HospitalLibrary.MedicalRecords.Model;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IPatientService
    {
        Patient Register(Patient patient);
        bool CheckExisting(Patient patient);
    }
}
