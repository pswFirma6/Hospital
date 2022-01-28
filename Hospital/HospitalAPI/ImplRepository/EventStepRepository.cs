using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository;


namespace HospitalAPI.ImplRepository
{
    public class EventStepRepository : Repository<EventStep>, IEventStepRepository
    {
        private readonly DatabaseEventContext _context;
        public EventStepRepository(DatabaseEventContext context)
            : base(context)
        {
        }

    }
}
