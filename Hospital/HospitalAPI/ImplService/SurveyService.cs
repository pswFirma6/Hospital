
using HospitalAPI.DTO;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using System.Collections.Generic;
using System.Linq;

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
            foreach (SurveyQuestion surveyQuestion in surveyQuestions)
            {
                _repositoryFactory.GetSurveyRepository().Add(surveyQuestion);
            }
        }

        public List<SurveyQuestion> GetAll()
        {
            return _repositoryFactory.GetSurveyRepository().GetAll();
            foreach (SurveyQuestion sq in _repositoryFactory.GetSurveyRepository().GetAll())
            {

            }

        }
        public List<SurveyRateDTO> GetGroupedByQuestion()
        {
            var allQuestions = _repositoryFactory.GetSurveyRepository().GetAll();
            var gropedByQuestion = (from q in allQuestions group q by q.QuestionText into g select new { QuestionText = g.Key, Questions = g.ToList() });

            List<SurveyRateDTO> lista = new List<SurveyRateDTO>();

            foreach(var aa in gropedByQuestion)
            {
                SurveyRateDTO surveyRateDTO = new SurveyRateDTO { QuestionText = aa.QuestionText, Rate = aa.Questions.Average(x => x.Rate) };
                lista.Add(surveyRateDTO);
            }
            return lista;
        }
    }
}
