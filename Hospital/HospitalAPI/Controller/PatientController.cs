﻿using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.ImplService;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(PatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
           
        }
        [HttpGet("{id}")]
        public IActionResult GetPatient(string id )
        {
            Patient patient = _patientService.GetPatient(id);
            var model = _mapper.Map<PatientDTO>(patient);
            return Ok(model);
        }
        [HttpGet]
        public IActionResult GetAllPatient()
        {
            List<Patient> patients = _patientService.GetAllPatient();
            
            return Ok(patients);
        }

    }
}
