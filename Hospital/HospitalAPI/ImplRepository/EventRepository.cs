using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplRepository
{
    public class EventRepository : Repository<AppointmentEvent>, IEventRepository
    {
        private readonly DatabaseEventContext _context;
        public EventRepository(DatabaseEventContext context) : base(context)
        {
            _context = context;
        }

    }
}
