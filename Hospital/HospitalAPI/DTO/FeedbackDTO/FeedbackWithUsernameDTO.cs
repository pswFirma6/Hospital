using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalAPI.DTO
{
    public class FeedbackWithUsernameDTO
    {

        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public FeedbackState State { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public FeedbackWithUsernameDTO(string username, string text, DateTime? date, FeedbackState state, bool anonymous, bool publish)
        {
            Username = username;
            Text = text;
            Date = date;
            State = state;
            Anonymous = anonymous;
            Publish = publish;
        }
    }
}
