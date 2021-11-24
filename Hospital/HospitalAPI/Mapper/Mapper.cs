using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

                CreateMap<Patient, PatientDTO>();
                CreateMap<PatientDTO, Patient>();

            }
        }
    } 
}