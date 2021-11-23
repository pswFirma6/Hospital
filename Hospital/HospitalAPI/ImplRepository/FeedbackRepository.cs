
using Hospital_library.MedicalRecords.Repository.Interface;
using Hospital_library.Model;
using Hospital_API;
using Hospital_library.MedicalRecords.Repository;

namespace Hospital_API.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MyDbContext context)
            : base(context)
        { }
    }
}
