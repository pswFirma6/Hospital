
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Allergy : Entity
    {
        public string Medicine { get; set; }
        public string ReactionType { get; set; }
        public string ReactionTime { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
