using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
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
        public List<Appointment> getAwaiting(int id);
        public List<Appointment> getCancelled(int id);
        public AllFreeTerms GetTerms(FreeTerms freeTermsRequest);
        public List<Appointment> getCompleted(int id);
        public bool CheckExistingAppointment(Appointment appointment);
        public void CancelAppointment(Appointment appointment);
        public int GetNumberOfCancelledApointmentByPatientId(int id);
    }
}
