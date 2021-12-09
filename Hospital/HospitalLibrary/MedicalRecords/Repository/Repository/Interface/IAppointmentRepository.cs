using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Appointment Add(Appointment appointment);
       
    }
}
