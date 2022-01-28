using Hospital_library.MedicalRecords.Model.Events;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IEventRepository 
    {
        AppointmentEvent AddEvent(AppointmentEvent e);
        List<AppointmentEvent> GetEventsAll();
        
    }
}
