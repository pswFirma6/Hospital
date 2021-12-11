using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _doctorService;
        
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("{Available}")]
        public IActionResult GetAvailableDoctors() 
        {
            return Ok(_doctorService.GetAvailable());
        }

        [HttpGet]
        [Route("{Specialists}/{type}")]
        public IActionResult GetSpecialistDoctors(DoctorType type)
        {
            return Ok(_doctorService.GetSpecialists(type));
        }

    }
}
