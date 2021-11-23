﻿using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.ImplService;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
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
