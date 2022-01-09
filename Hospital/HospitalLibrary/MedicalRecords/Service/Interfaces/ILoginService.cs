using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.Extensions.Configuration;

namespace Hospital_library.MedicalRecords.Service.Interfaces
{
    public interface ILoginService
    {
        public string GenerateJSONWebToken(User userInfo, IConfiguration _config);
        public User AuthenticateUser(User user);
    }
}
