using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
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
        public bool SurveyTaken { get; set; }
        public DateTime? DateCancelled { get; set; } 
        public AppointmentType Type { get; set; }
        public int PrescriptionID { get; set; }
        public virtual Prescription Prescription { get; set; }
        public string Report { get; set; }
        

        public Appointment() 
        {
        }
        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, AppointmentType type)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            Type = type;
        }
        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, AppointmentType type, bool surveyTaken)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            Type = type;
            SurveyTaken = surveyTaken;
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
