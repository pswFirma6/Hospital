﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class FreeTerms
    {
        public FreeTerms(DateTime date, string doctorId, string priority, List<string> terms)
        {
            Date = date;
            DoctorId = doctorId;
            Priority = priority;
            Terms = terms;
        }

        public FreeTerms(DateTime date, string doctorId, List<string> terms)
        {
            Date = date;
            DoctorId = doctorId;
            Terms = terms;
        }

        public DateTime Date { get; set; }
        public string DoctorId { get; set; }
        public string Priority { get; set; }
        public List<string> Terms { get; set; }
    }
}
