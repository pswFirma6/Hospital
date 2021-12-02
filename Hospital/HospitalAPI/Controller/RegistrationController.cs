using AutoMapper;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalAPI.DTO;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IPatientService _patientService;

        private readonly IRegistrationService _registrationService;

        private RegistrationValidation _registrationValidation; 
        
        private readonly IMapper _mapper;

        public RegistrationController(IPatientService patientService, 
            IRegistrationService registrationService,
            IMapper mapper, RegistrationValidation registrationValidation)
        {
            _patientService = patientService;
            _registrationService = registrationService;
            _mapper = mapper;
            _registrationValidation = registrationValidation;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PatientRegistrationDTO patientDTO)
        {
            if (!_registrationValidation.IsValid(patientDTO))
            {
                return BadRequest();
            }
            
            var model = _mapper.Map<Patient>(patientDTO);

            Patient patient = _patientService.Register(model);
            
            
            if (patient == null)
            {
                return Conflict(new { message = $"An existing record patient was already found." });
            }

            var registrated = _mapper.Map<PatientRegistration>(patientDTO);
            await _registrationService.EmailVerification(registrated);

            return Ok(patient);
        }


        [HttpGet("EmailConfirmation")]
        public IActionResult EmailConfirmation([FromQuery] string email, [FromQuery] string token)
        {
            //_registrationService
            //var user = await _registrationService.FindByEmailAsync(email);
            var user = _registrationService.FindByEmail(email);
            if (user == null)
                return BadRequest("Invalid Email Confirmation Request");

            //IdentityResult confirmResult = await _registrationService.ConfirmEmailAsync(user, token);

            //if (!confirmResult.Succeeded)
            //    return BadRequest("Invalid Email Confirmation Request");

            _registrationService.ActivateUser(user);
            return Ok();
        }
    }
}
