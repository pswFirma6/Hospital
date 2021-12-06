using Hospital_library.MedicalRecords.Service;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
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
    }
}
