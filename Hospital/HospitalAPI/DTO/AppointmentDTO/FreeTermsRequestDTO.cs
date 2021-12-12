using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalAPI.DTO.AppointmentDTO
{
    public class FreeTermsRequestDTO
    {
        public FreeTermsRequestDTO(string date, int doctorId, string priority)
        {
            Date = date;
            DoctorId = doctorId;
            Priority = priority;
        }

        public string Date { get; set; }
        public int DoctorId { get; set; }
        public string Priority { get; set; }

    }
}
