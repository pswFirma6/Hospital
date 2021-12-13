using HospitalAPI.DTO;
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
            if ( dto.StartTime <= DateTime.Now
                || dto.PatientId <= 0  || dto.DoctorId <= 0 )
            {
                return false;
            }

            return true;
        }
    }
}
