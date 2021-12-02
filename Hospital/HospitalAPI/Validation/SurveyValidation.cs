using HospitalAPI.DTO;
using HospitalAPI.DTO.SurveyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validation
{
    public class SurveyValidation
    {
        public bool IsValid(TakeSurveyDTO dto)
        {
            if (dto.Rate > 5 || dto.Rate < 1)
            {
                return false;
            }
            return true;
        }
    }
}