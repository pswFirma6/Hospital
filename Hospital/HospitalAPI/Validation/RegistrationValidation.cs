using Hospital_API.DTO;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.Model.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Validation
{
    public class RegistrationValidation
    {
        public bool IsValid(PatientDTO dto)
        {
            if ( dto.Name.Length <= 0 || dto.Surname.Length <= 0 || dto.BirthDate.Equals(null) 
                    || !dto.Jmbg.Length.Equals(13) || dto.Address.Length <= 0 || dto.Phone.Length <= 0 
                    || dto.Email.Length <= 0 || dto.Username.Length <= 0 || dto.Password.Length <= 0 
                    || !Enum.IsDefined(typeof(Gender), dto.Gender) || dto.City.Length <= 0 ||dto.Country.Length <= 0
                    || !Enum.IsDefined(typeof(UserType), dto.UserType) || !Enum.IsDefined(typeof(BloodType), dto.BloodType) 
                    || !Enum.IsDefined(typeof(RhFactor), dto.RhFactor) || dto.Height <= 0 || dto.Weight <= 0 
                    || dto.Doctor.Id.Equals(null) ) 
            {
                return false;
            }

            return true;
        }
    }
}
