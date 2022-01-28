using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Events;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Service.Interfaces
{
    public interface IEventService
    {
        int CountMonthsInEventStep(EventStep step, int count);
        int CountInstanscesOfEventStep(EventStep step, int count);
        List<int> getAverageTimePerEventStep();
        public AppointmentEvent CreateEventEntry(AppointmentEvent ev);
        public EventStep CreateStepEventEntry(EventStep ev);
        public List<AppointmentEvent> getAllAppointmentEvents();
        public List<AppointmentEvent> getAllUncreatedEvents();
        
        public List<AppointmentEvent> getAllCompletedAppointmentEvents();
        List<double> GetAverageStepTimes();
    }
}
