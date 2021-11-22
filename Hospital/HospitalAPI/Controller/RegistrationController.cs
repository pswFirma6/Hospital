using AutoMapper;
using Hospital_API.DTO;
using Hospital_API.ImplService;
using Hospital_API.Service;
using Hospital_API.Validation;
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

        private RegistrationValidation _registrationValidation; 
        
        private readonly IMapper _mapper;

        public RegistrationController(PatientService patientService, IMapper mapper, RegistrationValidation registrationValidation)
        {
            _patientService = patientService;
            _mapper = mapper;
            _registrationValidation = registrationValidation;
        }

        [HttpPost]
        public IActionResult Register(PatientDTO patientDTO)
        {
            if (!_registrationValidation.IsValid(patientDTO))
            {
                return BadRequest();
            }
            var model = _mapper.Map<Patient>(patientDTO);
            Patient registeredPatient =_patientService.Register(model);

            if (registeredPatient.Equals(null))
            {
                return Conflict(new { message = $"An existing record patient was already found." });
            }

            return Ok(registeredPatient);
        }

    }
}
