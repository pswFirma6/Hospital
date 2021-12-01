using Hospital_library.MedicalRecords.Service;
using HospitalAPI.EditorService;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorService doctorEditorService;
        private IDoctorService _doctorService;
        public DoctorController(DoctorService doctorEditorService,
            IDoctorService doctorService)
        {
            this.doctorEditorService = doctorEditorService;
            _doctorService = doctorService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(doctorEditorService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Doctor doctor)
        {
            doctorEditorService.create(doctor);
            return Ok();
        }


        [HttpGet]
        [Route("{Available}")]
        public IActionResult GetAvailableDoctors() 
        {
            return Ok(_doctorService.GetAvailable());
        }
    }
}
