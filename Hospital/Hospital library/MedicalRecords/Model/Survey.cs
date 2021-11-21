using Hospital_library.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords
{
    public class Survey : Entity
    {
        public List<SurveyQuestion> SurveyQuestions { get; set; }
        public Survey()
        {
            SurveyQuestions = new List<SurveyQuestion>();
        }

        
    }
}
