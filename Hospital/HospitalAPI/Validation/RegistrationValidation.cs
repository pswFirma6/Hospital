using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using System;

namespace HospitalAPI.Validation
{
    public class RegistrationValidation
    {
        public bool IsValid(PatientRegistrationDTO dto)
        {
            if (dto == null)
            {
                return false;
            }

            if (dto.Name.Length <= 0 || dto.Surname.Length <= 0 || dto.BirthDate == null
                    || !dto.Jmbg.Length.Equals(13) || dto.Address.Length <= 0 || dto.Phone.Length <= 0
                    || dto.Email.Length <= 0 || dto.Username.Length <= 0 || dto.Password.Length <= 0
                    || !Enum.IsDefined(typeof(Gender), dto.Gender) || dto.City.Length <= 0 || dto.Country.Length <= 0
                    || !Enum.IsDefined(typeof(UserType), dto.UserType) || !Enum.IsDefined(typeof(BloodType), dto.BloodType)
                    || !Enum.IsDefined(typeof(RhFactor), dto.RhFactor) || dto.Height <= 0 || dto.Weight <= 0
                    || dto.DoctorId <= 0)
            {
                return false;
            }
            
            
            return true;
        }
    }
}
