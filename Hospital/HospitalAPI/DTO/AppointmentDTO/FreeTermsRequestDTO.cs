using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalAPI.DTO.AppointmentDTO
{
    public class FreeTermsRequestDTO
    {
        public FreeTermsRequestDTO(string date, string doctorId, string priority)
        {
            Date = date;
            DoctorId = doctorId;
            Priority = priority;
        }

        public string Date { get; set; }
        public string DoctorId { get; set; }
        public string Priority { get; set; }

    }
}
