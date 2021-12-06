using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using System;

namespace HospitalAPI.DTO
{
    public class NewAppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public NewAppointmentDTO(DateTime startDate, double duration, DateTime date, int roomId, Room room, string patientId, Patient patient, string doctorId, Doctor doctor)
        {
            this.StartTime = startDate;
            this.Duration = duration;
            this.Date = date;
            this.RoomId = roomId;
            this.Room = room;
            this.PatientId = patientId;
            this.Patient = patient;
            this.DoctorId = doctorId;
            this.Doctor = doctor;
        }
    }
}
