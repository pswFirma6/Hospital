using HospitalLibrary.GraphicalEditor.Model;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public Appointment() 
        {
        }
        public Appointment(DateTime startDate, double duration, DateTime date, int roomId, Room room, string patientId, Patient patient, string doctorId, Doctor doctor)
        {
            StartTime = startDate;
            Duration = duration;
            Date = date;
            RoomId = roomId;
            Room = room;
            PatientId = patientId;
            Patient = patient;
            DoctorId = doctorId;
            Doctor = doctor;
        }
    }
}
