using System;

namespace HospitalAPI.DTO
{
    public class ViewFeedbackDTO
    {
        public string PersonName { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }

        public ViewFeedbackDTO(string personName, string text, DateTime? date)
        {
            PersonName = personName;
            Text = text;
            Date = date;
        }
    }
}
