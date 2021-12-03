using HospitalLibrary.MedicalRecords.Model.Enums;

namespace HospitalAPI.DTO.SurveyDTO
{
    public class TakeSurveyDTO
    {
        public TakeSurveyDTO(string questionText, SurveyQuestionCategory category)
        {
            QuestionText = questionText;
            Category = category;
        }

        public TakeSurveyDTO(string personId, string questionText, int rate, SurveyQuestionCategory category)
        {
            PersonId = personId;
            QuestionText = questionText;
            Rate = rate;
            Category = category;
        }
        public TakeSurveyDTO() { }
        public string PersonId { get; set; }
        public string QuestionText { get; set; }
        public int Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}