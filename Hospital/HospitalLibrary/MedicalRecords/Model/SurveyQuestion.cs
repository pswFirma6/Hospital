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

        public SurveyQuestion(string questionText, SurveyQuestionCategory category, int rate, string id)
        {
            QuestionText = questionText;
            Category = category;
            Rate = rate;
            PersonId = id;
        }

        public SurveyQuestion() { }
        public string PersonId { get; set; }
        public string QuestionText { get; set; }
        public double Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}
