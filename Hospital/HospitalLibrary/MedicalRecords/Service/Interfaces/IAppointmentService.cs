﻿using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IAppointmentService
    {
        public bool CheckDoctorAppointments(Appointment newAppointment);
        public void Add(Appointment appointment);
        public List<string> GetDoctorsFreeAppointments(int doctorId, string dateString);
        public List<Appointment> getAll(int id);
        public List<Appointment> getAwaiting(int id);

        public List<Appointment> getCancelled(int id);
    }
}
