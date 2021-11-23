using AutoMapper;
using Hospital_API.DTO;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Mapper
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

                CreateMap<Patient, PatientDTO>();
                CreateMap<PatientDTO, Patient>();

            }
        }
    } 
}