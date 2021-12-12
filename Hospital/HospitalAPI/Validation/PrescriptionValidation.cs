using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validation
{
    public class PrescriptionValidation
    {
        public bool AreDatesValid(string start, string end)
        {
            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);
            return DateTime.Compare(endDate, startDate) > 0;
        }
    }
}
