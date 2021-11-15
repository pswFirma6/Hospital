using Hospital_library.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class FeedbackResponseDTO
    {
        public string PersonId { get; set; }
        public string Text { get; set; }
        public FeedbackState State { get; set; }
    }
}
