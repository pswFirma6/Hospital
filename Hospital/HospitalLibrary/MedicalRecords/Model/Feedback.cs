using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.Model
{
    public class Feedback : Entity
    {
        public string PersonId { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public FeedbackState State { get; set; } = FeedbackState.pending;
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
    }
}
