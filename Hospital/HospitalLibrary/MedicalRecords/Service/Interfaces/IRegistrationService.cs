using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalRecords.Repository.Repository.Interface
{
    public interface IRegistrationService
    {
        Task EmailVerification(PatientRegistration patient);
        Task<PatientRegistration> FindByEmailAsync(string email);
        Task<IdentityResult> ConfirmEmailAsync(PatientRegistration user, string token);
        void ActivateUser(Patient patient);
        Patient FindByEmail(string email);
    }
}
