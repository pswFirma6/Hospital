
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.Model;
using HospitalAPI;
using HospitalLibrary.MedicalRecords.Repository;

namespace HospitalAPI.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MyDbContext context)
            : base(context)
        { }
    }
}
