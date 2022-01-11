using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model.Enums;

namespace HospitalAPI.Validation
{
    public class LoginValidation
    {
        public bool IsValid(LoginDTO dto)
        {
            if (dto == null)
            {
                return false;
            }
            if (dto.Username.Length < 5 || dto.Password.Length < 8 || ( !dto.UserType.Equals(UserType.patient) && !dto.UserType.Equals(UserType.manager ) ))
            {
                return false;
            }

            return true;
        }
    }
}
