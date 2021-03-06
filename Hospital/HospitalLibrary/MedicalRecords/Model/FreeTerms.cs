using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class FreeTerms
    {
        public FreeTerms(DateTime date, int doctorId, string priority, List<string> terms)
        {
            Date = date;
            DoctorId = doctorId;
            Priority = priority;
            Terms = terms;
        }

        public FreeTerms(DateTime date, int doctorId, List<string> terms)
        {
            Date = date;
            DoctorId = doctorId;
            Terms = terms;
        }

        public FreeTerms()
        {
        }

        public FreeTerms(DateTime date, int doctorId, Doctor doctor, List<string> terms)
        {
            Date = date;
            DoctorId = doctorId;
            Doctor = doctor;
            Terms = terms;
        }

        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Priority { get; set; }
        public List<string> Terms { get; set; }
    }
}
