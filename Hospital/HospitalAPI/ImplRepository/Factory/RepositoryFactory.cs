using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalAPI.ImplRepository;
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using System;

namespace HospitalAPI.Repository
{
    public abstract class RepositoryFactory
    {
        public abstract IFeedbackRepository GetFeedbackRepository();

        public abstract IPatientRepository GetPatientRepository();

        public abstract ISurveyRepository GetSurveyRepository();

        public abstract IAllergyRepository GetAllergyRepository();

        public abstract IDoctorRepository GetDoctorsRepository();

        public abstract IAppointmentRepository GetAppointmentsRepository();

        public abstract IMedicineRepository GetMedicineRepository();

    }
}
