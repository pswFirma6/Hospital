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
            if (dto == null)
            {
                return false;
            }

            if (dto.Text.Length <= 0 || dto.PersonId <= 0)
            {
                return false;
            }
            
            return true;
        }
    }
}
