using Hospital_library.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class MedicalRecord : Entity
    {
        public string PersonId { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Allergy> Allergies { get; set; }
    }
}
