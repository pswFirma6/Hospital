using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplRepository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DatabaseEventContext context) : base(context)
        {

        }
        public void SaveEvent()
        {
            _eventContext.SaveChanges();
        }
    }
}
