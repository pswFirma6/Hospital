using Hospital_library.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class FeedbackStateChangeDTO
    {
        public string Id { get; set; }
        public string State { get; set; }
    }
}
