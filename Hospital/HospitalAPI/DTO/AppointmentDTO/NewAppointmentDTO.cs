using HospitalLibrary.MedicalRecords.Model;
using System;

namespace HospitalAPI.DTO
{
    public class NewAppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public NewAppointmentDTO()
        {
                
        }

        public NewAppointmentDTO(DateTime startDate, int patientId, int doctorId)
        {
            this.StartTime = startDate;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
        }

        public NewAppointmentDTO(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor)
        {
            this.StartTime = startDate;
            this.PatientId = patientId;
            this.Patient = patient;
            this.DoctorId = doctorId;
            this.Doctor = doctor;
        }
    }
}
