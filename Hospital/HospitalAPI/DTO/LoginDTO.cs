using HospitalLibrary.MedicalRecords.Model.Enums;

namespace HospitalAPI.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public LoginDTO() 
        {
        }
        public LoginDTO(string username, string password, UserType userType) 
        {
            Username = username;
            Password = password;
            UserType = userType;
        }

    }
}
