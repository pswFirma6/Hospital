
using Hospital_API.DTO;
using Hospital_API.Repository;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using System.Collections.Generic;

namespace Hospital_API.ImplService
{
    public class SurveyService : ISurveyService
    {
        public HospitalRepositoryFactory _repositoryFactory;

        public SurveyService(HospitalRepositoryFactory repositoryFactory, MyDbContext aa)
        {
            _repositoryFactory = repositoryFactory;
        }
    }
}
