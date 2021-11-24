
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.Model;
using HospitalAPI;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalAPI.Repository
{
    public class SurveyRepository : Repository<SurveyQuestion>, IFeedbackRepository
    {
        public SurveyRepository(MyDbContext context)
            : base(context)
        { }
    }
}
