
using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class MedicalRecord : ValueObject
    {
        public int MedRecordId { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public int Height { get; private  set; }
        public int Weight { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BloodType;
            yield return RhFactor;
            yield return Height;
            yield return Weight;

        }


        public MedicalRecord(int medRecordId,BloodType bloodType, RhFactor rhFactor, int height, int weight)
        {
            MedRecordId = medRecordId;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Height = height;
            Weight = weight;
        }

        public MedicalRecord()
        {
        }
    }
}
