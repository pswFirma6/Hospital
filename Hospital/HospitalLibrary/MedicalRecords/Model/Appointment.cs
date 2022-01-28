using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using HospitalLibrary.GraphicalEditor.Model;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        private AppointmentType awaiting;

        public DateTime StartTime { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public bool SurveyTaken { get; set; }
        public DateTime? DateCancelled { get; set; } 
        public AppointmentType Type { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        public string DoctorReport { get; set; }

        public Appointment() 
        {
        }
        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, AppointmentType type, int prescriptionId)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            Type = type;
            PrescriptionId = prescriptionId;
        }
        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, AppointmentType type, bool surveyTaken, int prescriptionId)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            Type = type;
            SurveyTaken = surveyTaken;
            PrescriptionId = prescriptionId;
        }

        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, int prescriptionId)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            PrescriptionId = prescriptionId;
        }

        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
        }

        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, Prescription prescription, string doctorReport)
        {
            StartTime = startDate;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            Prescription = prescription;
        }

        public Appointment(DateTime startDate, int patientId, Patient patient, int doctorId, Doctor doctor, AppointmentType awaiting) : this(startDate, patientId, patient, doctorId, doctor)
        {
            this.awaiting = awaiting;
        }
    }
}
