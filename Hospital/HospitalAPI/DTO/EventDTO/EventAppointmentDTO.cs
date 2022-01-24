using System;

namespace HospitalAPI.DTO.EventDTO
{
    public class EventAppointmentDTO
    {
        public string Name { get; set; }
        public DateTime ClickTime { get; set; }
        public string ApplicationName { get; set; }
        public double TimeSpan { get; set; }
        public int? DoctorId { get; set; }

        public EventAppointmentDTO(String name, DateTime date, String applicationName, double timeSpan, int doctorId)
        {
            Name = name;
            ClickTime = date;
            ApplicationName = applicationName;
            TimeSpan = timeSpan;
            DoctorId = doctorId;
        }

    }
}
