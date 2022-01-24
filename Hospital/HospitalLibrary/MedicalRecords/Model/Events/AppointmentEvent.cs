using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model.Events
{
    public class AppointmentEvent : Entity
    {
        public string Name { get; set; }
        public DateTime ClickTime { get; set; }
        public string ApplicationName { get; set; }
        public double TimeSpan { get; set; }
        public int? DoctorId { get; set; }
        public virtual ICollection<EventStep> EventsStep { get; set; }

    }
}
