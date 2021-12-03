using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Allergy : Entity
    {
        public string Name { get; set; }

        public Allergy(string name)
        {
            Name = name;
        }
    }
}
