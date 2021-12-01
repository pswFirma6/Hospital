
namespace HospitalLibrary.MedicalRecords.Model
{
    public class Email
    {
        public string Form { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
