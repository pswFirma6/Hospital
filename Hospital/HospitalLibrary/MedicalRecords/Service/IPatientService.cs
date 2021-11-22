using Hospital_library.MedicalRecords.Model;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IPatientService
    {
        Patient Register(Patient patient);
        bool CheckExisting(Patient patient);
    }
}
