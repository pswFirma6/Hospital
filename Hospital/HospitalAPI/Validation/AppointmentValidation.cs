using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;

namespace HospitalAPI.Validation
{
    public class AppointmentValidation
    {
        public bool IsValid(NewAppointmentDTO dto)
        {
            if (dto == null)
            {
                return false;
            }
            if ( dto.PatientId <= 0 || dto.DoctorId <= 0)
            {
                return false;
            }

            return true;
        }

        public bool RequestIsValid(FreeTermsRequestDTO dto)
        {
            if (dto == null)
            {
                return false;
            }
           
            if (dto.DoctorId <= 0 || !(dto.Priority == "doctor" || dto.Priority == "date"))
            {
                return false;
            }
            return true;
        }

        public bool DoctorTypeRequestIsValid(string doctorType)
        {
            try
            {
                DoctorType type = (DoctorType)Enum.Parse(typeof(DoctorType), doctorType);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
