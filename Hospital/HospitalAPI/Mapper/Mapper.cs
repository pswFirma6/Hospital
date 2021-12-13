using AutoMapper;
using Hospital_library.MedicalRecords.Model;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.DTO.SurveyDTO;
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

                
                CreateMap<SurveyQuestion, TakeSurveyDTO>();
                CreateMap<TakeSurveyDTO, SurveyQuestion>();

                CreateMap<FreeTermsRequestDTO, FreeTerms>();
                CreateMap<FreeTerms, FreeTermsRequestDTO>();
                
                CreateMap<Appointment, NewAppointmentDTO>();
                CreateMap<NewAppointmentDTO, Appointment>();
            }
        }
    } 

}