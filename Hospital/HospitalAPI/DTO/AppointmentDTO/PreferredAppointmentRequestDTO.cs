using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalAPI.DTO
{
    public class PreferredAppointmentRequestDTO
    {
        public PreferredAppointmentRequestDTO(string date, int doctorId, DoctorType doctorType, string preferred)
        {
            Date = date;
            DoctorId = doctorId;
            DoctorType = doctorType;
            Preferred = preferred;
        }

        public string Date { get; set; }
        public int DoctorId { get; set; }
        public DoctorType DoctorType { get; set; }
        public string Preferred { get; set; }
    }
}
