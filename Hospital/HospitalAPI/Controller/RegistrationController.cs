using AutoMapper;
using Hospital_API.DTO;
using Hospital_API.Validation;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IPatientService _patientService;

        private IRegistrationService _registrationService;

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

            if (patient.Equals(null))
            {
                return Conflict(new { message = $"An existing record patient was already found." });
            }

            var registrated = _mapper.Map<PatientRegistration>(patientDTO);
            await _registrationService.EmailVerification(registrated);

            return Ok(patient);
        }
    }
}
