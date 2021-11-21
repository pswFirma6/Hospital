using AutoMapper;
using Hospital_API.DTO;
using Hospital_API.ImplService;
using Hospital_API.Service;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Service;
using Hospital_library.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private PatientService _patientService;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public RegistrationController(PatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Register(Patient patient)
        {
            // TODO: this controller method will accept patient DTO and map it to patient and send to service
            Patient registeredPatient =_patientService.Register(patient);

            return Ok(registeredPatient);
        }
    }
}
