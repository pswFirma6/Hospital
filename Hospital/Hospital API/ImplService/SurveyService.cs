
using Hospital.Model;
using Hospital_API.Repository;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
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

        public List<SurveyQuestion> InitializeSurvey()
        {
            SurveyQuestion surveyQuestion1 = new SurveyQuestion("Question1", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            SurveyQuestion surveyQuestion2 = new SurveyQuestion("Question2", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            SurveyQuestion surveyQuestion3 = new SurveyQuestion("Question3", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);

            List<SurveyQuestion> survey = new List<SurveyQuestion>();
            survey.AddRange(new List<SurveyQuestion>() { surveyQuestion1, surveyQuestion2, surveyQuestion3 });
            return survey;
        }
    }
}
