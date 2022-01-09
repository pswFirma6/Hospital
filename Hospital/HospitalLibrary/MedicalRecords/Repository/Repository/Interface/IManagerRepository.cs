using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IManagerRepository
    {
        Manager GetByLoginCredentials(string username, string password, UserType userType);
    }
}
