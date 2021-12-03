using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class ViewFeedback
    {
        public string PersonName { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }

        public ViewFeedback(string personName, string text, DateTime? date)
        {
            PersonName = personName;
            Text = text;
            Date = date;
        }
    }
}
