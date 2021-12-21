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
        public FreeTermsForApp GetAllFreeTerms(int DoctorId, DateTime startDate);
        public List<string> GetDoctorsFreeAppointments(int doctorId, DateTime date);
        public List<Appointment> getAll(int id);
        public List<Appointment> getAwaiting(int id);
        public List<Appointment> getCancelled(int id);
        List<Appointment> getCompleted(int id);
        void CancelAppointment(Appointment appointment);
        bool CheckExistingAppointment(Appointment appointment);
        FreeTerms GetTerms(FreeTerms freeTermsRequest);
    }
}
