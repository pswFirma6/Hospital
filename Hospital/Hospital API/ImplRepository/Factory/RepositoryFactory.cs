


using Hospital_API.ImplRepository;

namespace Hospital_API.Repository
{
    public abstract class RepositoryFactory
    {
        public abstract FeedbackRepository GetFeedbackRepository();

        public abstract PersonRepository GetPersonRepository();
    }
}
