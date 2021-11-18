using AutoMapper;
using Hospital_API.DTO;
using Hospital_library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Mapper
{
    public class FeedbackMapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects
                CreateMap<Feedback, FeedbackDTO>();
                CreateMap<FeedbackDTO, Feedback>();

                CreateMap<Feedback, FeedbackStateChangeDTO>();
                CreateMap<FeedbackStateChangeDTO, Feedback>();

            }
        }
    } 
}