
using Hospital_library.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Allergy : Entity
    {
        public virtual AllergyDescription Description { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
