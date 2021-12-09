using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalAPI.DTO.AppointmentDTO
{
    public class FreeTermsDTO
    {
        public FreeTermsDTO(DateTime date, List<string> terms, string doctorId, Doctor doctor)
        {
            Date = date;
            Terms = terms;
            DoctorId = doctorId;
            Doctor = doctor;
        }

        public DateTime Date { get; set; }
        public List<string> Terms { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
