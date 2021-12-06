using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalAPI.ImplRepository;
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;

namespace HospitalAPI.Repository
{
    public abstract class RepositoryFactory
    {
        public abstract IFeedbackRepository GetFeedbackRepository();

        public abstract IPatientRepository GetPatientRepository();

        public abstract ISurveyRepository GetSurveyRepository();

        public abstract IAllergyRepository GetAllergyRepository();

        public abstract IDoctorRepository GetDoctorRepository();

        public abstract IMedicineRepository GetMedicineRepository();
        public abstract IPrescriptionRepository GetPrescriptionRepository();
    }
}
