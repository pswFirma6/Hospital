using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using System.Linq;

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
    }
}

