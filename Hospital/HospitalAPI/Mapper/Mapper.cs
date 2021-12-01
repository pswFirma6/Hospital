using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;

namespace HospitalAPI.Mapper
{
    public class Mapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
            
                CreateMap<Feedback, FeedbackDTO>();
                CreateMap<FeedbackDTO, Feedback>();

                CreateMap<Feedback, FeedbackStateChangeDTO>();
                CreateMap<FeedbackStateChangeDTO, Feedback>();

                CreateMap<Patient, PatientRegistrationDTO>();

                CreateMap<PatientRegistrationDTO, Patient>();

                CreateMap<PatientRegistration, PatientRegistrationDTO>();
                CreateMap<PatientRegistrationDTO, PatientRegistration>();

            }
        }
    } 
}