using Hospital_library.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service
{
    public interface ISurveyService
    {
        List<SurveyQuestion> InitializeSurvey();
    }
}
