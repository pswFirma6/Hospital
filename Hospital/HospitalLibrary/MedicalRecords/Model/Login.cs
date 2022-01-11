using HospitalLibrary.MedicalRecords.Model.Enums;

namespace Hospital_library.MedicalRecords.Model
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
