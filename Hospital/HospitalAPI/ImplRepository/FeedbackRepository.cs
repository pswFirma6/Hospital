
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalAPI.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MyDbContext context)
            : base(context)
        { 
        }
    }
}
