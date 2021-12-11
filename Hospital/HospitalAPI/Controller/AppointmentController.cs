using AutoMapper;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;
        private AppointmentValidation _appointmentValidation;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, AppointmentValidation appointmentValidation, IMapper mapper) 
        {
            _appointmentService = appointmentService;
            _appointmentValidation = appointmentValidation;
            _mapper = mapper;
        }

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
        [Route("Priority")]
        public IActionResult GetPriorityAppointments(FreeTermsRequestDTO freeTermsRequestDTO)
        {
            
            return BadRequest();
        }
    }
}
