using System;
using System.Collections.Generic;
using System.Text;
using static Hospital_library.MedicalRecords.Model.AllergyDescription;

namespace Hospital_library.MedicalRecords.Model
{
    public class Therapy : ValueObject
    {
        public string TherapyStart { get; private set; }
        public string TherapyEnd { get; private set; }
        public string Diagnosis { get; private  set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TherapyStart;
            yield return TherapyEnd;
            yield return Diagnosis;
        }

        public Therapy(string therapyStart, string therapyEnd, string diagnosis)
        {
            TherapyStart = therapyStart;
            TherapyEnd = therapyEnd;
            Diagnosis = diagnosis;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(TherapyStart) || string.IsNullOrEmpty(TherapyEnd) || string.IsNullOrEmpty(Diagnosis))
                throw new ConnectionInfoException("Therapy info cannot be empty");
        }
       
    }
}
