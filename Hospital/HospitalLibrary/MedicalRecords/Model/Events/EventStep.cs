using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model.Events
{
    public class EventStep : Entity
    {
        public string Name { get; set; }
        public double TimeSpan { get; set; }
        public DateTime ClickTime { get; set; }
        public int AppointmentEventId { get; set; }
        public virtual AppointmentEvent AppointmentEvent { get; set; }

        
    }
}
