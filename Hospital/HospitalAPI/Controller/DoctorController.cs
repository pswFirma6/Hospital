using HospitalAPI.EditorService;
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
    public class DoctorController : ControllerBase
    {
        public DoctorService doctorService;

        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(doctorService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Doctor doctor)
        {
            doctorService.create(doctor);
            return Ok();
        }
    }
}
