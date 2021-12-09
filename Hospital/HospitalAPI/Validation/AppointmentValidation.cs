using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                || dto.RoomId <= 0 || dto.Room == null
                || dto.PatientId == ("") || dto.Patient == null || dto.DoctorId == ("")
                || dto.Doctor == null)
            {
                return false;
            }

            return true;
        }
    }
}
