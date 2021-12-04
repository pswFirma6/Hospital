using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Feedback : Entity
    {
        public int PersonId { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public FeedbackState State { get; set; } = FeedbackState.pending;
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
    }
}
