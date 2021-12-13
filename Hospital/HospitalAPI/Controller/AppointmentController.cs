using AutoMapper;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly AppointmentValidation _appointmentValidation;
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

            //if (_appointmentService.CheckDoctorAppointments(mapper)) 
            //{
            //    return Conflict(new { message = $"An existing appointment was found in doctor appointment list." });
            //}
            _appointmentService.Add(mapper);

            return Ok(mapper);
        }
        
        [HttpGet]
        public IActionResult GetAllAppointment(int id)
        {
            return Ok(_appointmentService.getAll(id));
        }
        
        [HttpGet]
        [Route("{awaiting}")]
        public IActionResult GetAwaitingAppointment(int id)
        {
            return Ok(_appointmentService.getAwaiting(id));
        }

        [HttpGet]
        [Route("{cancelled}")]
        public IActionResult GetCancelledAppointment(int id)
        {
            return Ok(_appointmentService.getCancelled(id));
        }

        [HttpPost]
        [Route("Priority")]
        public IActionResult GetPriorityAppointments(FreeTermsRequestDTO freeTermsRequestDTO)
        {
            if (!_appointmentValidation.RequestIsValid(freeTermsRequestDTO))
            {
                return BadRequest();
            }
            var mapper = _mapper.Map<FreeTerms>(freeTermsRequestDTO);
            FreeTerms freeTerms = _appointmentService.GetTerms(mapper);
            return Ok(freeTerms);
        }

        //[HttpGet]
        //[Route("{AppointmentForm}")]
        //public IActionResult GetDoctorsAndTypes(string doctorType)
        //{
        //    if (!_appointmentValidation.DoctorTypeRequestIsValid(doctorType))
        //    {
        //        return BadRequest();
        //    }
        //    DoctorType type = (DoctorType)Enum.Parse(typeof(DoctorType), doctorType);

        //    return Ok(_appointmentService.GetTypeDoctors(type));
        //}
    }
}

