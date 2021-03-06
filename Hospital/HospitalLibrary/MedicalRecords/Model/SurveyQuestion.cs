using HospitalLibrary.MedicalRecords.Model.Enums;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class SurveyQuestion : Entity
    {
        public SurveyQuestion(string questionText, SurveyQuestionCategory category)
        {
            QuestionText = questionText;
            Category = category;
        }

        public SurveyQuestion(string questionText, SurveyQuestionCategory category, int rate, int id)
        {
            QuestionText = questionText;
            Category = category;
            Rate = rate;
            PersonId = id;
        }

        public SurveyQuestion() { }
        public int PersonId { get; set; }
        public string QuestionText { get; set; }
        public int Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}
