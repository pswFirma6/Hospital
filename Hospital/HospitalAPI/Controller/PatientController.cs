using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
           
        }

        [Authorize(Roles = "patient")]
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            Patient patient = _patientService.GetPatient(id);
            var model = _mapper.Map<PatientRegistrationDTO>(patient);
            return Ok(model);
        }
 
        [HttpGet]
        public IActionResult GetMaliciousPatients()
        {
            return Ok(_patientService.GetMaliciousPatients());
        }

        [HttpPut]
        public IActionResult BlockPatient(Patient patient)
        {
            _patientService.BlockPatient(patient);
            return Ok(patient);
        }

        [HttpPut]
        public IActionResult UnblockPatient(Patient patient)
        {
            _patientService.UnblockPatient(patient);
            return Ok(patient);
        }

        [Authorize(Roles = "patient")]
        [HttpGet]
        [Route("getByUsername/{username}")]
        public IActionResult GetPatientByUsername(string username)
        {
            if (username != null)
            {
                return Ok(_patientService.GetPatientByUsername(username));
            }

            return BadRequest();
        }

    }
}
