using System;
using System.Collections.Generic;
using System.Text;
using static Hospital_library.MedicalRecords.Model.AllergyDescription;

namespace Hospital_library.MedicalRecords.Model
{
    public class Dosage: ValueObject
    {
       
        public int Quantity { get; private set; }
        public string RecommendedDose { get; private  set; }
        public string PrescriptionDate { get; private  set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Quantity;
            yield return RecommendedDose;
            yield return PrescriptionDate;
        }

        public Dosage(int quantity, string recommendedDose, string prescriptionDate)
        {
            
            Quantity = quantity;
            RecommendedDose = recommendedDose;
            PrescriptionDate = prescriptionDate;
            Validate();
        }
        private void Validate()
        {
            if (Quantity <0 || string.IsNullOrEmpty(RecommendedDose))
                throw new ConnectionInfoException("Values cannot be less then 0 or empty strings");
        }
        
        
    }
}
