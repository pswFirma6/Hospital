using System;

namespace HospitalAPI.DTO.EventDTO
{
    public class EventStepDTO
    {
        public string Name { get; set; }
        public double TimeSpan { get; set; }
        public DateTime ClickTime { get; set; }
        public int AppointmentEventId { get; set; }

        public EventStepDTO(string name, double timeSpan, DateTime dateTime, int appointmentEventId) 
        {
            Name = name;
            TimeSpan = timeSpan;
            ClickTime = dateTime;
            AppointmentEventId = appointmentEventId;
        }

    }
}
