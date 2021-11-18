using Hospital_library.MedicalRecords.Repository.Interface;
using Hospital_library.Model;
using Hospital_API;
using Hospital_library.MedicalRecords.Repository;

namespace Hospital_API.ImplRepository
{
    public class PersonRepository : Repository<Person>, IFeedbackRepository
    {
        public PersonRepository(MyDbContext context)
            : base(context)
        { }
    }
}

