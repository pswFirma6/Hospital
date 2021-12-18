using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO.AppointmentDTO
{
    public class TermDTO
    {
        public int DoctorId { get; set;}
        public DateTime StartDate { get; set; }

        public TermDTO(int doctorId, DateTime startDate)
        {
            this.DoctorId = doctorId;
            this.StartDate = startDate;
        }

    }
}
