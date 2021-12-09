using Hospital_library.MedicalRecords.Model.Enums;
using HospitalLibrary.GraphicalEditor.Model;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public AppointmentType AppointmentType { get; set; }

        public Appointment() 
        {
        }
        public Appointment(DateTime startDate, int roomId, Room room, string patientId, Patient patient, string doctorId, Doctor doctor, AppointmentType appointmentType)
        {
            StartTime = startDate;
            RoomId = roomId;
            Room = room;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
            AppointmentType = appointmentType;
        }
    }
}
