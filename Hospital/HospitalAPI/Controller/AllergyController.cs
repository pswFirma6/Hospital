using Hospital_library.MedicalRecords.Service;
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
    public class AllergyController : ControllerBase
    {
        private IAllergyService _allergyService;

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
