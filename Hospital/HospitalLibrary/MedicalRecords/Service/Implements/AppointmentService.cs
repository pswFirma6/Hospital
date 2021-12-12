using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System.Collections.Generic;
using System.Linq;


namespace HospitalAPI.ImplService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

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

            return existingDoctor.Appointments.Any( x => x.StartTime.Equals(newAppointment.StartTime) 
                    || ( newAppointment.StartTime <= x.StartTime.AddMinutes(30)  
                    &&  x.StartTime <= newAppointment.StartTime)); 
        }

        public List<Appointment> getAll(int id)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            List<Appointment> appointmentsList = _hospitalRepositoryFactory.GetAppointmentsRepository().GetAll();
            foreach (Appointment appointment in appointmentsList)
            {
                if(appointment.PatientId == id)
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
        public List<string> GetDoctorsFreeAppointments(int doctorId, string dateString)
        {
            List<string> terms = new List<string>(InitializedTerms);
            var existingDoctor = _hospitalRepositoryFactory.GetDoctorsRepository().GetOne(doctorId);
            List<Appointment> DoctorAppointments = existingDoctor.Appointments.Where(x => x.StartTime.ToString("dd/MM/yyyy").Equals(dateString)).ToList();
            if (DoctorAppointments.Count != 0)
            {
                foreach (Appointment appointment in DoctorAppointments)
                {
                    foreach (string time in terms.ToArray())
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
    }
}
