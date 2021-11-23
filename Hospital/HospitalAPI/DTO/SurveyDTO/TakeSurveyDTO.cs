using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO.SurveyDTO
{
    public class TakeSurveyDTO
    {
        public TakeSurveyDTO(string questionText, SurveyQuestionCategory category)
        {
            QuestionText = questionText;
            Category = category;
        }

        public TakeSurveyDTO() { }
        public string PersonId { get; set; }
        public string QuestionText { get; set; }
        public int Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}