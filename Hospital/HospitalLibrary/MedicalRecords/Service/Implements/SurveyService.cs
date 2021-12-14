using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplService
{
    public class SurveyService : ISurveyService
    {
        public RepositoryFactory _repositoryFactory;

        public SurveyService(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public void Add(List<SurveyQuestion> surveyQuestions)
        {
            foreach (SurveyQuestion surveyQuestion in surveyQuestions)
            {
                _repositoryFactory.GetSurveyRepository().Add(surveyQuestion);
            }
        }

        public List<SurveyQuestion> GetGroupedByQuestion()
        {
            var allQuestions = _repositoryFactory.GetSurveyRepository().GetAll();
            var gropedByQuestion = (from q in allQuestions group q by q.QuestionText into g select new { QuestionText = g.Key, Questions = g.ToList() });

            List<SurveyQuestion> lista = new List<SurveyQuestion>();

            foreach(var aa in gropedByQuestion)
            {
                SurveyQuestion surveyRateDTO = new SurveyQuestion { QuestionText = aa.QuestionText, Rate = Math.Round(aa.Questions.Average(x => x.Rate),2), Category = aa.Questions.FirstOrDefault().Category };
                lista.Add(surveyRateDTO);
            }
            return lista;
        }

        public List<SurveyQuestion> GetGroupedByCategory()
        {
            var allQuestions = _repositoryFactory.GetSurveyRepository().GetAll();
            var gropedByQuestion = (from q in allQuestions group q by q.Category into g select new { Category = g.Key, Questions = g.ToList() });

            List<SurveyQuestion> lista = new List<SurveyQuestion>();

            foreach(var aa in gropedByQuestion)
            {
                SurveyQuestion surveyRateDTO = new SurveyQuestion { Category = aa.Category, Rate = Math.Round(aa.Questions.Average(x => x.Rate),2) };
                lista.Add(surveyRateDTO);
            }
            return lista;
        }
    }
}
