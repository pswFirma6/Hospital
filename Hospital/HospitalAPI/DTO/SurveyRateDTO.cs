using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class SurveyRateDTO
    {
        public string QuestionText { get; set; }
        public double Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }

    }

    public class SurveryCategoryDTO
    {
        public double Rate { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}
