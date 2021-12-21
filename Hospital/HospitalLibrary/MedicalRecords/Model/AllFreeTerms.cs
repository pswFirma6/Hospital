using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class AllFreeTerms
    {
        public AllFreeTerms(List<FreeTerms> freeTermsList)
        {
            FreeTermsList = freeTermsList;
        }

        public List<FreeTerms> FreeTermsList { get; set; }
    }
}
