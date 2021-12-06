using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalAPI.ImplRepository;
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;

namespace HospitalAPI.Repository
{
    public class HospitalRepositoryFactory : RepositoryFactory
    {
        private MyDbContext _context;
        public HospitalRepositoryFactory(MyDbContext context)
        {
            _context = context;
        }
        public IFeedbackRepository FeedbackRepository { get; set; }
        public IPatientRepository PersonRepository { get; set; }
        public ISurveyRepository SurveyRepository { get; set; }
        public IAllergyRepository AllergyRepository { get; set; }
        public IDoctorRepository DoctorRepository { get; set; }
        public IAppointmentRepository AppointmentRepository { get; set; }
        public override IFeedbackRepository GetFeedbackRepository()
        {
            if (FeedbackRepository == null)
                return new FeedbackRepository(_context);
            else
                return FeedbackRepository;
        }

        public override IPatientRepository GetPatientRepository()
        {
            if (PersonRepository == null)
                return new PatientRepository(_context);
            else
                return PersonRepository;
        }

        public override ISurveyRepository GetSurveyRepository()
        {
            if (SurveyRepository == null)
                return new SurveyRepository(_context);
            else
                return SurveyRepository;
        }

        public override IAllergyRepository GetAllergyRepository()
        {
            if (AllergyRepository == null)
                return new AllergyRepository(_context);
            else
                return AllergyRepository;
        }
        public override IDoctorRepository GetDoctorsRepository() 
        {
            if (DoctorRepository == null)
                return new DoctorRepository(_context);
            else
                return DoctorRepository;
        }
        public override IAppointmentRepository GetAppointmentsRepository()
        {
            if (AppointmentRepository == null)
                return new AppointmentRepository(_context);
            else
                return AppointmentRepository;
        }
    }
}
