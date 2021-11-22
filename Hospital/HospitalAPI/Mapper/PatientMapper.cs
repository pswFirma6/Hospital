using AutoMapper;
using Hospital_API.DTO;
using Hospital_library.MedicalRecords.Model;


namespace Hospital_API.Mapper
{
    public class PatientMapper
    {
        public class PatientMappingProfile : Profile
        {
            public PatientMappingProfile()
            {
                CreateMap<Patient, PatientDTO>();
                CreateMap<PatientDTO, Patient>();
            }
        }
    }
}
