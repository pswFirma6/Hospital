using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository.Interface
{
    public interface ISurveyRepository
    {
        SurveyQuestion Add(SurveyQuestion surveyQuestion);
        List<SurveyQuestion> GetAll();
    }
}
