using HospitalLibrary.GraphicalEditor.Model;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        public string StartTime { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }
        public string RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
