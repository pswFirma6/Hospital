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

        private List<string> InitializedTerms = new List<string> { 
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
        /*
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

                }
            }

            return null;
        }
        */

        public List<string> GetDoctorsFreeAppointments(int doctorId, string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MM/dd/yyyy", null);
            List<string> terms = InitializedTerms;
            var existingDoctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(doctorId);
            List<Appointment> DoctorAppointments = existingDoctor.Appointments.Where(x => x.StartTime.ToString("dd/MM/yyyy").Equals(date.ToString("dd/MM/yyyy"))).ToList();
            if(DoctorAppointments != null)
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
        /*
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
            if(doctors == null)
            {
                return null;
            }
            Doctor minAppDoc = doctors.First();
            foreach(Doctor appDoc in doctors)
            {   
                if(GetDoctorsFreeAppointments(minAppDoc.Id, dateString).Count != InitializedTerms.Count)
                {
                    if(GetDoctorsFreeAppointments(appDoc.Id, dateString).Count > GetDoctorsFreeAppointments(minAppDoc.Id, dateString).Count)
                    {
                        minAppDoc = appDoc;
                    }
                }
            }
            FreeTermsDTO freeTermsDTO = new FreeTermsDTO(DateTime.ParseExact(dateString, "MM/dd/yyyy", null)
                , GetDoctorsFreeAppointments(minAppDoc.Id, dateString),minAppDoc.Id , minAppDoc);
            return freeTermsDTO;
        }
        */
        public List<Doctor> GetTypeDoctors(DoctorType type)
        {
             return _hospitalRepositoryFactory.GetDoctorsRepository().GetAll().Where(x => x.DoctorType == type).ToList();
        }
    }
}
