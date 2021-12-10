using Hospital_library.MedicalRecords.Model.Enums;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
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
            if (dto.StartTime <= DateTime.Now || (dto.Duration < 30 && dto.Duration > 30)
                || dto.Date <= DateTime.Now || dto.RoomId <= 0 || dto.Room == null
                || dto.PatientId <= 0 || dto.Patient == null || dto.DoctorId <= 0
                || dto.Doctor == null)
            {
                return false;
            }

            return true;
        }
        public bool IsAwaiting(Appointment appointment)
        {
            if (appointment == null)
            {
                return false;
            }
            if (appointment.Type != AppointmentType.Awaiting)
            {
                return false;
            }
            return true;
        }
    }
}
