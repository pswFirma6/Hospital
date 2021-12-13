using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using System;
using System.Collections.Generic;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IAppointmentService
    {
        public bool CheckDoctorAppointments(Appointment newAppointment);
        public void Add(Appointment appointment);
        public List<string> GetDoctorsFreeAppointments(int doctorId, DateTime dateString);
        public List<Appointment> getAll(int id);
        public List<Appointment> getAwaiting(int id);
        public List<Appointment> getCancelled(int id);
        public List<Appointment> getCompleted(int id);
        public FreeTerms GetTerms(FreeTerms freeTermsRequest);
        public FreeTerms GetAlternativeDate(Doctor doctor, DateTime date);
        public FreeTerms GetAlternativeDoctor(Doctor doctor, DateTime date);
        public List<Doctor> GetTypeDoctors(DoctorType type);


    }
}
