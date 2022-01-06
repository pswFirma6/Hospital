using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service.Implements
{
    public class EventService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public EventService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public EventService()
        {
        }

        public List<Event> GetAll()
        {
            return _hospitalRepositoryFactory.GetEventRepository().GetAll();
        }
        public void Add(Event e)
        {
            _hospitalRepositoryFactory.GetEventRepository().Add(e);
        }
        public void CreateEventEntry(String appName, String eventName)
        {
            Event e = new Event();
            e.Id = GetAll().Count + 1;
            e.ApplicationName = appName;
            e.ClickTime = DateTime.Now;
            e.Name = eventName;
            Add(e);
        }
    }
}
