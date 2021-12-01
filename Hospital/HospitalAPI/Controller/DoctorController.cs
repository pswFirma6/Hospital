using Hospital_library.MedicalRecords.Service;
using HospitalAPI.ImplService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;
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
    }
}
