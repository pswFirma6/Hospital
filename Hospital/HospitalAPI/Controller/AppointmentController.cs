using AutoMapper;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.Validation;
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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly AppointmentValidation _appointmentValidation;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, AppointmentValidation appointmentValidation, IMapper mapper, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _appointmentValidation = appointmentValidation;
            _mapper = mapper;
            _patientService = patientService;
        }

        [Authorize(Roles = "patient")]
        [HttpPost]
        public IActionResult AddAppointment(NewAppointmentDTO newAppointment)
        {
            if (!_appointmentValidation.IsValid(newAppointment)) 
            {
                return BadRequest();
            }

            var mapper = _mapper.Map<Appointment>(newAppointment);

            if (_appointmentService.CheckDoctorAppointments(mapper)) 
            {
                return Conflict(new { message = $"An existing appointment was found in doctor appointment list." });
            }
            _appointmentService.Add(mapper);

            return Ok(mapper);
        }
        
        
        [HttpPost]
        [Route("doctorAppintments")]
        public IActionResult GetDoctorAppointments(TermDTO termDTO)
        {
            return Ok(_appointmentService.GetAllFreeTerms(termDTO.DoctorId, termDTO.StartDate));
        }

        [Authorize(Roles = "patient")]
        [HttpGet]
        [Route("awaiting/{id}")]
        public IActionResult GetAwaitingAppointment(int id)
        {
            return Ok(_appointmentService.getAwaiting(id));
        }

        [Authorize(Roles = "patient")]
        [HttpGet]
        [Route("cancelled/{id}")]
        public IActionResult GetCancelledAppointment(int id)
        {
            return Ok(_appointmentService.getCancelled(id));
        }

        [Authorize(Roles = "patient")]
        [HttpGet]
        [Route("completed/{id}")]
        public IActionResult GetCompletedAppointment(int id)
        {
            return Ok(_appointmentService.getCompleted(id));
        }

        [HttpPut]
        public IActionResult CancelAppointment(Appointment appointment)
        {
            if (!_appointmentService.CheckExistingAppointment(appointment))
            {
                return Conflict(new { message = $"The appointment does not exist in the database" });
            }
            if (!_appointmentValidation.IsAwaiting(appointment))
            {
                return BadRequest();
            }

            _appointmentService.CancelAppointment(appointment);

            int numberOfCancelledAppointments = _appointmentService.GetNumberOfCancelledApointmentByPatientId(appointment.PatientId);

            if (numberOfCancelledAppointments >= 3)
            {
                _patientService.SetPatientMaliciousStatus(appointment.PatientId, true);
            }
    
            return Ok(appointment);
        }

        [Authorize(Roles = "patient")]
        [HttpPost("Priority")]
        public IActionResult GetPriorityAppointments(FreeTermsRequestDTO freeTermsRequestDTO)
        {
            if (!_appointmentValidation.RequestIsValid(freeTermsRequestDTO))
            {
                return BadRequest();
            }
            var mapper = _mapper.Map<FreeTerms>(freeTermsRequestDTO);
            AllFreeTerms allFreeTerms = _appointmentService.GetTerms(mapper);
            return Ok(allFreeTerms);
        }
    }
}

