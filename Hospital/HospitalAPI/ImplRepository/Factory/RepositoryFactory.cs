using HospitalAPI.ImplRepository;

namespace HospitalAPI.Repository
{
    public abstract class RepositoryFactory
    {
        public abstract FeedbackRepository GetFeedbackRepository();

        public abstract PatientRepository GetPatientRepository();
    }
}
