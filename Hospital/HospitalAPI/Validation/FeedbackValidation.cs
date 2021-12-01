using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validation
{
    public class FeedbackValidation
    {
        public bool IsValid(FeedbackDTO dto) 
        {
            if (dto.Text.Length <= 0 || String.IsNullOrEmpty(dto.PersonId))
            {
                return false;
            }
            else if (dto == null)
            {
                return false;
            }

            return true;
        }
    }
}
