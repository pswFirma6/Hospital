using Hospital_library.MedicalRecords.Service;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
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
            _hospitalRepositoryFactory.GetAppointmentsRepository().Add(appointment);
        }

        public bool CheckDoctorAppointments(Appointment newAppointment) 
        {
            var existingDoctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(newAppointment.DoctorId);

            return existingDoctor.Appointments.Any( x => x.StartTime.Equals(newAppointment.StartTime) 
                    || ( newAppointment.StartTime <= x.StartTime.AddMinutes(30)  
                    &&  x.StartTime <= newAppointment.StartTime)); 
        }

        public FreeTermsDTO GetTerms(FreeTermsRequestDTO freeTermsRequestDTO)
        {
            var doctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(freeTermsRequestDTO.DoctorId);
            if (freeTermsRequestDTO.Priority.Equals("doctor"))
            {
                List<string> terms = GetDoctorsFreeAppointments(doctor.Id, freeTermsRequestDTO.Date);
                if(terms.Count == 0)
                {
                    return GetAlternativeDate(doctor, freeTermsRequestDTO.Date);
                }
                else
                {
                    FreeTermsDTO freeTermsDTO = new FreeTermsDTO(DateTime.ParseExact(freeTermsRequestDTO.Date, "MM/dd/yyyy", null),
                            terms, doctor.Id, doctor);
                }
            }else if (freeTermsRequestDTO.Priority.Equals("date"))
            {
                List<string> terms = GetDoctorsFreeAppointments(freeTermsRequestDTO.DoctorId, freeTermsRequestDTO.Date);
                if(terms.Count == 0)
                {
                    return GetAlternativeDoctor(doctor, freeTermsRequestDTO.Date);
                }
            }

            return null;
        }


        public List<string> GetDoctorsFreeAppointments(string doctorId, string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MM/dd/yyyy", null);
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

        public FreeTermsDTO GetAlternativeDate(Doctor doctor, string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MM/dd/yyyy", null);
            DateTime alternativeDate = date.AddDays(1);
            List<string> freeTerms = GetDoctorsFreeAppointments(doctor.Id, alternativeDate.ToString("dd/MM/yyyy"));
            FreeTermsDTO freeTermsDTO = new FreeTermsDTO(alternativeDate, freeTerms, doctor.Id, doctor);
            return freeTermsDTO;
        }

        public FreeTermsDTO GetAlternativeDoctor(Doctor doctor, string dateString)
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
                var minAppDoctorsFreeAppintments = GetDoctorsFreeAppointments(minAppDoc.Id, dateString).Count;
                if (minAppDoctorsFreeAppintments != MaxFreeTerms)
                {
                    var appDocFreeTerms = GetDoctorsFreeAppointments(appDoc.Id, dateString);
                    if (appDocFreeTerms.Count > minAppDoctorsFreeAppintments)
                    {
                        minAppDoc = appDoc;
                    }
                }
            }
            FreeTermsDTO freeTermsDTO = new FreeTermsDTO(DateTime.ParseExact(dateString, "MM/dd/yyyy", null)
                , GetDoctorsFreeAppointments(minAppDoc.Id, dateString),minAppDoc.Id , minAppDoc);
            return freeTermsDTO;
        }

        public List<Doctor> GetTypeDoctors(DoctorType type)
        {
             return _hospitalRepositoryFactory.GetDoctorsRepository().GetAll().Where(x => x.DoctorType == type).ToList();
        }
    }
}
