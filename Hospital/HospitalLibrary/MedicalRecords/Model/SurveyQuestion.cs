using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class SurveyQuestion : Entity
    {
        public SurveyQuestion(string questionText, SurveyQuestionCategory category)
        {
            QuestionText = questionText;
            Category = category;
        }

        public SurveyQuestion() { }

        public SurveyQuestion(string personId, string questionText, int rate, SurveyQuestionCategory category)
        {
            PersonId = personId;
            QuestionText = questionText;
            Rate = rate;
            Category = category;
        }

        public string PersonId { get; set; }
        public string QuestionText { get; set; }
        public int Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}
