using HospitalLibrary.MedicalRecords.Model;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalRecords.Repository.Repository.Interface
{
    public interface IRegistrationService
    {
        Task EmailVerification(PatientRegistration patient);
    }
}
