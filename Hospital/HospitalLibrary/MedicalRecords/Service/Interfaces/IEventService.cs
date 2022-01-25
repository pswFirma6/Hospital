using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Events;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Service.Interfaces
{
    public interface IEventService
    {
        public AppointmentEvent CreateEventEntry(AppointmentEvent ev);
        public EventStep CreateStepEventEntry(EventStep ev);
        public List<AppointmentEvent> getAllAppointmentEvents();
        public List<AppointmentEvent> getAllUncreatedEvents();
        
    }
}
