﻿using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Appointment Add(Appointment appointment);
        Appointment GetOne(int id);
        Appointment Update(Appointment appointment);
    }
}
