using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_library.MedicalRecords.Service.Implements
{
    public class EventService : IEventService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public EventService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public AppointmentEvent CreateEventEntry(AppointmentEvent ev)
        {

            _hospitalRepositoryFactory.GetEventRepository().AddEvent(ev);
            
            return ev;
        }

        public EventStep CreateStepEventEntry(EventStep ev)
        {
            EventStep e = new EventStep();
            e.AppointmentEventId = ev.AppointmentEventId;
            e.ClickTime = DateTime.Now;
            e.Name = ev.Name;
            e.TimeSpan = ev.TimeSpan;

            _hospitalRepositoryFactory.GetEventStepRepository().AddEvent(e);

            return e;
        }
        
        public List<AppointmentEvent> getAllAppointmentEvents()
        {
            return _hospitalRepositoryFactory.GetEventRepository().GetEventsAll();
        }

        public List<AppointmentEvent> getAllUncreatedEvents()
        {
            List<AppointmentEvent> uncreatetEvents = new List<AppointmentEvent>(); 
               uncreatetEvents = _hospitalRepositoryFactory.GetEventRepository().GetEventsAll()
                    .Where(x => x.AppointmentCreated.Equals(false)).ToList(); ;
            
            return uncreatetEvents;
        }


    }

}
