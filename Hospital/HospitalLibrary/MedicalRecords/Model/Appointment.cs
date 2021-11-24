using System;

namespace Hospital_library.MedicalRecords.Model
{
    public class Appointment : Entity
    {
        public string StartTime { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }
        public Room Room { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
