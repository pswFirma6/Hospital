
using HospitalAPI.DTO;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using System.Collections.Generic;

namespace HospitalAPI.ImplService
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
