using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTO;
using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HospitalAPI.Controller
{
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly string integrationServer = "https://localhost:44325";

        public PrescriptionController(IPrescriptionService prescriptionService, IMapper mapper)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        [Route("savePrescription")]
        public IActionResult SavePrescription(Prescription prescription)
        {
            _prescriptionService.AddPrescription(prescription);
            SendPrescription(prescription);
            return Ok();
        }

        private void SendPrescription(Prescription prescription)
        {
            var client = new RestClient(integrationServer);
            var request = new RestRequest("/sendPrescription", Method.POST);
            request.AddJsonBody(prescription);
            client.Post(request);
        }


    }
}
