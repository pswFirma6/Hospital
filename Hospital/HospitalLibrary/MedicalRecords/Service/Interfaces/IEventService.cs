using Hospital_library.MedicalRecords.Model.Events;

namespace Hospital_library.MedicalRecords.Service.Interfaces
{
    public interface IEventService
    {
        public AppointmentEvent CreateEventEntry(AppointmentEvent ev);
        public EventStep CreateStepEventEntry(EventStep ev);
    }
}
