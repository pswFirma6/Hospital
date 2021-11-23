
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

        public void Add(List<SurveyQuestion> surveyQuestions)
        {
            foreach(SurveyQuestion surveyQuestion in surveyQuestions)
            {
                _repositoryFactory.GetSurveyRepository().Add(surveyQuestion);
            }
        }
    }
}