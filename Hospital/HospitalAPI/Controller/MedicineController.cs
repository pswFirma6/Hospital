using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.ImplService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost]
        [Route("urgentProcurement")]
        public IActionResult UrgentProcurement(Medicine medicine)
        {
            _medicineService.UrgentProcurement(medicine);
            return Ok();
        }
    }
}
