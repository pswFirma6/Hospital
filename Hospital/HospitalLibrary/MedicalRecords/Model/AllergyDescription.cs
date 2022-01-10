using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class AllergyDescription : ValueObject
    {
        public int DescriptionID { get; private set; }
        public string Medicine { get; private set; }
        public string ReactionType { get; private set; }
        public string ReactionTime { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Medicine;
            yield return ReactionType;
            yield return ReactionTime;
        }

        public AllergyDescription(int descriptionID, string medicine, string reactionType, string reactionTime)
        {
            DescriptionID = descriptionID;
            Medicine = medicine;
            ReactionType = reactionType;
            ReactionTime = reactionTime;
            Validate();
        }

        public AllergyDescription()
        {
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Medicine) || string.IsNullOrEmpty(ReactionType) || string.IsNullOrEmpty(ReactionTime))
                throw new ConnectionInfoException("Allergy description  cannot be empty");
        }
        public class ConnectionInfoException : Exception
        {
            public ConnectionInfoException(String message) : base(message) { }

        }

    }
}
