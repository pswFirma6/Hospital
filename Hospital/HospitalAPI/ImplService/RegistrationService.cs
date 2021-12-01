using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalAPI.ImplService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<PatientRegistration> _userManager;
        private IEmailSender _emailSender;
        private RepositoryFactory _factory;

        public RegistrationService(UserManager<PatientRegistration> userManager, 
            IEmailSender emailSender, RepositoryFactory factory) 
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _factory = factory;
        }

        public void ActivateUser(Patient patient)
        {
            patient.Activated = true;
            _factory.GetPatientRepository().Update(patient);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(PatientRegistration user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }


        public async Task EmailVerification(PatientRegistration registrated)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(registrated);
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", registrated.Email }
            };
            var callback = QueryHelpers.AddQueryString("http://localhost:4200/authentication/emailconfirmation", param);
            var message = new Message(new string[] { registrated.Email }, "Email Confirmation token", callback);
            await _emailSender.SendEmailAsync(message);
        }

        public Patient FindByEmail(string email)
        {
            return _factory.GetPatientRepository().GetByEmail(email);
        }

        public async Task<PatientRegistration> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
