using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class FeedbackResponseDTO
    {
        public int PersonId { get; set; }
        public string Text { get; set; }
        public FeedbackState State { get; set; }
    }
}
