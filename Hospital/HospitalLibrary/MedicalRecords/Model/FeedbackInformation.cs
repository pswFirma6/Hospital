using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Hospital_library.MedicalRecords.Model.AllergyDescription;

namespace Hospital_library.MedicalRecords.Model
{
    public class FeedbackInformation : ValueObject
    {
        public FeedbackInformation()
        {
        }

        public int FdbInfId { get; private set; }
        public string Text { get; private set; }
        public DateTime? Date { get; private set; }
        public FeedbackState State { get; private set; } = FeedbackState.pending;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Text;
            yield return Date;
            yield return State;
        }

        public FeedbackInformation(int fdbInfId, string text, DateTime? date, FeedbackState state)
        {
            FdbInfId = fdbInfId;
            Text = text;
            Date = date;
            State = state;
            Validate();
        }
        private void ValidateText()
        {
            if (string.IsNullOrEmpty(Text))
                throw new ConnectionInfoException("Feedback body  cannot be empty");
        }
        private void ValidateDate()
        {
            if(Date>DateTime.Now)
                throw new ConnectionInfoException("Date  cannot be higher than the current date  ");
        }
        private void Validate()
        {
            ValidateDate();
            ValidateText();
        }
        
    }
}
