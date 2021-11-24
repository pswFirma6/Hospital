using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using System.Threading.Tasks;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IRegistrationService
    {
        Task EmailVerification(PatientRegistration patient);
    }
}
