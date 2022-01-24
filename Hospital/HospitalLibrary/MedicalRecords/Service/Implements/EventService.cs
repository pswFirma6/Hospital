using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;

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
            AppointmentEvent e = new AppointmentEvent();
            e.ApplicationName = ev.ApplicationName;
            e.ClickTime = DateTime.Now;
            e.Name = ev.Name;
            e.DoctorId = ev.DoctorId;  // can be null
            e.TimeSpan = ev.TimeSpan;

            _hospitalRepositoryFactory.GetEventRepository().AddEvent(e);
            
            return e;
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

    }
}
