using HospitalAPI.ImplRepository;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Repository.Interface;


namespace HospitalAPI.Repository
{
    public class HospitalRepositoryFactory : RepositoryFactory
    {
        private MyDbContext _context;
        public HospitalRepositoryFactory(MyDbContext context)
        {
            _context = context;
        }
        public FeedbackRepository FeedbackRepository { get; set; }
        public PatientRepository PersonRepository { get; set; }
        public SurveyRepository SurveyRepository { get; set; }

        public override FeedbackRepository GetFeedbackRepository()
        {
            if (FeedbackRepository == null)
                return new FeedbackRepository(_context);
            else
                return FeedbackRepository;
        }

        public override PatientRepository GetPatientRepository()
        {
            if (PersonRepository == null)
                return new PatientRepository(_context);
            else
                return PersonRepository;
        }

        public override SurveyRepository GetSurveyRepository()
        {
            if (SurveyRepository == null)
                return new SurveyRepository(_context);
            else
                return SurveyRepository;
        }

    }
}
