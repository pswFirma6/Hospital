
using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface ISurveyService
    {
        public void Add(List<SurveyQuestion> surveyQuestions);

        public List<SurveyQuestion> GetGroupedByCategory();
        public List<SurveyQuestion> GetGroupedByQuestion();

    }
}
