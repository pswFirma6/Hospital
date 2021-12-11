using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IAppointmentService
    {
        public bool CheckDoctorAppointments(Appointment newAppointment);
        public void Add(Appointment appointment);
        public FreeTerms GetTerms(FreeTerms freeTermsRequest);
        public List<string> GetDoctorsFreeAppointments(string doctorId, DateTime date);
        public FreeTerms GetAlternativeDate(Doctor doctor, DateTime date);
        public FreeTerms GetAlternativeDoctor(Doctor doctor, DateTime date);
        public List<Doctor> GetTypeDoctors(DoctorType type);
    }
}
