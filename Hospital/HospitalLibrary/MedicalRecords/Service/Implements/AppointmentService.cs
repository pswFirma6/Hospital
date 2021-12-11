using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
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

        
    }
}
