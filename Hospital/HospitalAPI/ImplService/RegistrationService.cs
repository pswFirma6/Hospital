using Hospital_API.DTO;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
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

        public RegistrationService(UserManager<PatientRegistration> userManager, IEmailSender emailSender) 
        {
            _userManager = userManager;
            _emailSender = emailSender;
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
    }
}
