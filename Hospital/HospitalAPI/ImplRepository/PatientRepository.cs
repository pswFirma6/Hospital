using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using System.Linq;
using HospitalLibrary.MedicalRecords.Model.Enums;

namespace HospitalAPI.ImplRepository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly MyDbContext _context;
        public PatientRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Patient GetByUniqueFields(string username, string email, string jmbg)
        {
            return _context.Patients.SingleOrDefault(s => s.Username == username || s.Email == email || s.Jmbg == jmbg);
        }
        public Patient GetByEmail(string email)
        {
            return _context.Patients.SingleOrDefault(s => s.Email == email);
        }
        public Patient GetByLoginCredentials(string username, string password, UserType userType)
        {
            return _context.Patients.SingleOrDefault(p => p.Username == username && p.Password == password && p.UserType == userType);
        }
        public Patient GetByUsername(string username)
        {
            return _context.Patients.SingleOrDefault(p => p.Username == username);
        }

        public void SetPatientMaliciousStatus(int id, bool status)
        {
            Patient patient = _context.Patients.First(x => x.Id == id);

            patient.Malicious = status;

            _context.SaveChanges();
        }
    }
}

