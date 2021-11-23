using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class FeedbackDTO
    {
        public string PersonId { get; set; }
        public string Text { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
    }
}
