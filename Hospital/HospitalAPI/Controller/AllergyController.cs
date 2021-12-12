using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyService _allergyService;

        public AllergyController(IAllergyService allergyService) 
        {
            _allergyService = allergyService;
        }

        [HttpGet]
        public IActionResult GetAllergy() 
        {
            List<Allergy> allergies = _allergyService.GetAllergies();
            if (allergies == null || allergies.Count <= 0)
            {
                return NoContent(); 
            }

            return Ok(allergies);
        }
    }
}
