using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
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
            if (dto.StartTime <= DateTime.Now
                || dto.PatientId <= 0 || dto.Patient == null || dto.DoctorId <= 0
                || dto.Doctor == null)
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
            DateTime date = DateTime.Parse(dto.Date,
                                      System.Globalization.CultureInfo.InvariantCulture);
            if (date <= DateTime.Now || dto.DoctorId <= 0 || !dto.Equals("date") && !dto.Equals("doctor"))
            {
                return false;
            }
            return true;
        }
    }
}
