using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalAPI.DTO
{
    public class PreferredAppointmentRequestDTO
    {
        public PreferredAppointmentRequestDTO(string date, string doctorId, DoctorType doctorType, string preferred)
        {
            Date = date;
            DoctorId = doctorId;
            DoctorType = doctorType;
            Preferred = preferred;
        }

        public string Date { get; set; }
        public string DoctorId { get; set; }
        public DoctorType DoctorType { get; set; }
        public string Preferred { get; set; }
    }
}
