using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Feedback : Entity
    {
        public int PersonId { get; set; }
        public virtual FeedbackInformation Information { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
    }
}
