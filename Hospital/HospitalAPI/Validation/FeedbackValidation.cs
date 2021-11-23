using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Validation
{
    public class FeedbackValidation
    {
        public bool IsValid(FeedbackDTO dto) 
        {
            if ( dto.Text.Length <= 0 || String.IsNullOrEmpty(dto.PersonId) )
            {
                return false;
            }

            return true;
        }
    }
}
