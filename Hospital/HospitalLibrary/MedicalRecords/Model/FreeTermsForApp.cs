using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Model
{
    public class FreeTermsForApp : Entity
    {
        public int DoctorId { get; set; }
        public List<DateTime> Terms { get; set; }
    }
}
