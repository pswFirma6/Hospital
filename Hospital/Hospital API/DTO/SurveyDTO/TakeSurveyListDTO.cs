using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO.SurveyDTO
{
    public class TakeSurveyListDTO
    {
        public string PersonId { get; set; }
        public List<TakeSurveyDTO> SurveyQuestions { get; set; }
    }
}