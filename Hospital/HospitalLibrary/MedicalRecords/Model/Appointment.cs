using HospitalLibrary.GraphicalEditor.Model;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public Appointment() 
        {
        }
        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
        }
    }
}
