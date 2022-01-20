using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplRepository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly MyDbContext _context;
        public AppointmentRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }

        public int GetNumberOfCancelledApointmentByPatientId(int id)
        {
            return _context.Appointments.Where(x => x.PatientId == id && x.DateCancelled >= System.DateTime.Now.AddMonths(-1)).Count();
        }

        public Prescription GetPrescription(int id)
        {
            return (Prescription)_context.Prescriptions.Where(x => x.Id == id);
        }
    }
}
