using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        [Route("savePrescription")]
        public IActionResult SavePrescription(Prescription prescription)
        {
            _prescriptionService.AddPrescription(prescription);
            return Ok();
        }
    }
}
