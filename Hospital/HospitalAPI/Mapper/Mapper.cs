using AutoMapper;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Events;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.DTO.EventDTO;
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

                CreateMap<Appointment, NewAppointmentDTO>();
                CreateMap<NewAppointmentDTO, Appointment>();

                CreateMap<User, LoginDTO>();
                CreateMap<LoginDTO, User>();

                CreateMap<AppointmentEvent, EventAppointmentDTO>();
                CreateMap<EventAppointmentDTO, AppointmentEvent>();

                CreateMap<EventStep, EventStepDTO>();
                CreateMap<EventStepDTO, EventStep>();

            }
        }
    } 

}