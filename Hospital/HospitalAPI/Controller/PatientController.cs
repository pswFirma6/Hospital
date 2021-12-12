using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.ImplService;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
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
        private IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
           
        }
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id )
        {
            Patient patient = _patientService.GetPatient(id);
            var model = _mapper.Map<PatientRegistrationDTO>(patient);
            return Ok(model);
        }
       

    }
}
