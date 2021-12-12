using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HospitalAPI.ImplService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;
        private List<string> InitializedTerms = new List<string>{
                "07:00", "07:30",
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };
        public AppointmentService(RepositoryFactory hospitalRepositoryFactory) 
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public void Add(Appointment appointment)
        {
            appointment.Doctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(appointment.DoctorId);
            appointment.Patient = _hospitalRepositoryFactory.GetPatientRepository().GetOne(appointment.PatientId);
            _hospitalRepositoryFactory.GetAppointmentsRepository().Add(appointment);
        }

        public bool CheckDoctorAppointments(Appointment newAppointment)
        {
            var existingDoctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(newAppointment.DoctorId);

            return existingDoctor.Appointments.Any(x => x.StartTime.Equals(newAppointment.StartTime)
                   || (newAppointment.StartTime <= x.StartTime.AddMinutes(30)
                   && x.StartTime <= newAppointment.StartTime));
        }

        public List<Appointment> getAll(int id)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            List<Appointment> appointmentsList = _hospitalRepositoryFactory.GetAppointmentsRepository().GetAll();
            foreach (Appointment appointment in appointmentsList)
            {
                if (appointment.PatientId == id)
                {
                    allAppointments.Add(appointment);
                }
            }
            return allAppointments;
        }

        public List<Appointment> getAwaiting(int id)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            List<Appointment> appointmentsList = _hospitalRepositoryFactory.GetAppointmentsRepository().GetAll();
            foreach (Appointment appointment in appointmentsList)
            {
                if (appointment.PatientId == id && appointment.Type == AppointmentType.Awaiting)
                {
                    allAppointments.Add(appointment);

                }
            }
            return allAppointments;
        }

        public List<Appointment> getCancelled(int id)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            List<Appointment> appointmentsList = _hospitalRepositoryFactory.GetAppointmentsRepository().GetAll();
            foreach (Appointment appointment in appointmentsList)
            {
                if (appointment.PatientId == id && appointment.Type == AppointmentType.Cancelled)
                {
                    allAppointments.Add(appointment);
                }
            }
            return allAppointments;
        }

        public FreeTerms GetTerms(FreeTerms freeTermsRequest)
        {
            var doctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(freeTermsRequest.DoctorId);
            List<string> terms = GetDoctorsFreeAppointments(doctor.Id, freeTermsRequest.Date);
            if (terms.Count != 0)
            {
                FreeTerms freeTerms = new FreeTerms(freeTermsRequest.Date, doctor.Id, terms);
                return freeTerms;
            }
            else
            {
                if (freeTermsRequest.Priority.Equals("doctor"))
                {
                    return GetAlternativeDate(doctor, freeTermsRequest.Date);
                }
                else if (freeTermsRequest.Priority.Equals("date"))
                {
                    return GetAlternativeDoctor(doctor, freeTermsRequest.Date);
                }
            }
            return null;
        }


        public List<string> GetDoctorsFreeAppointments(int doctorId, DateTime date)
        {
            List<string> terms = new List<string>(InitializedTerms);
            var existingDoctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(doctorId);
            List<Appointment> DoctorAppointments = existingDoctor.Appointments.Where(x => x.StartTime.ToString("dd/MM/yyyy").Equals(date.ToString("dd/MM/yyyy"))).ToList();
            if(DoctorAppointments.Count != 0)
            {
                foreach (Appointment appointment in DoctorAppointments)
                {
                    foreach(string time in terms.ToArray())
                    {
                        if (appointment.StartTime.ToString("HH:mm").Equals(time))
                        {
                            terms.Remove(time);
                            break;
                        }
                    }
                }
            }
            return terms;
        }

        public FreeTerms GetAlternativeDate(Doctor doctor, DateTime date)
        {
            DateTime alternativeDate = date.AddDays(1);
            List<string> terms = GetDoctorsFreeAppointments(doctor.Id, alternativeDate);
            FreeTerms freeTerms = new FreeTerms(alternativeDate, doctor.Id, terms);
            return freeTerms;
        }

        public FreeTerms GetAlternativeDoctor(Doctor doctor, DateTime date)
        {
            List<Doctor> doctors = GetTypeDoctors(doctor.DoctorType);
            if(doctors == null || doctors.Count == 1)
            {
                return null;
            }
            Doctor minAppDoc = doctors.First();
            int MaxFreeTerms = InitializedTerms.Count;
            foreach(Doctor appDoc in doctors)
            {
                var minAppDoctorsFreeAppintments = GetDoctorsFreeAppointments(minAppDoc.Id, date).Count;
                if (minAppDoctorsFreeAppintments != MaxFreeTerms)
                {
                    var appDocFreeTerms = GetDoctorsFreeAppointments(appDoc.Id, date);
                    if (appDocFreeTerms.Count > minAppDoctorsFreeAppintments)
                    {
                        minAppDoc = appDoc;
                    }
                }
            }
            FreeTerms freeTerms = new FreeTerms(date, minAppDoc.Id, GetDoctorsFreeAppointments(minAppDoc.Id, date));

            return freeTerms;
        }
        public List<Doctor> GetTypeDoctors(DoctorType type)
        {
            return _hospitalRepositoryFactory.GetDoctorsRepository().GetSpecialists(type);
        }
    }
}
