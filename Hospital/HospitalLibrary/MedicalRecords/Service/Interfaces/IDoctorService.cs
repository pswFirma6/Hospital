using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IDoctorService
    {
        public List<Doctor> GetAvailable();
        public List<Doctor> GetSpecialists(DoctorType type);
    }
}
