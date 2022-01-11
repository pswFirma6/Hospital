using AutoMapper;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.Controller
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        private IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _appointmentService = appointmentService;
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
            List<Patient> patients = _patientService.GetMaliciousPatients();

            if(patients == null)
            {
                return Ok(new List<Patient>());
            }
            foreach (Patient patient in patients.AsEnumerable())
            {
                int numberOfCancelledAppointments = _appointmentService.GetNumberOfCancelledApointmentByPatientId(patient.Id);
                if (numberOfCancelledAppointments == 0)
                {
                    _patientService.SetPatientMaliciousStatus(patient.Id, false);
                    patients.Remove(patient);
                }
            }
            
            return Ok(patients);
        }

        [HttpPut("BlockPatient")]
        public IActionResult BlockPatient(Patient patient)
        {
            _patientService.BlockPatient(patient);
            return Ok(patient);
        }

        [HttpPut("Unblockpatient")]
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
