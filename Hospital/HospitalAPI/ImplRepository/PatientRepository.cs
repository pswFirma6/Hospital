using Hospital_library.MedicalRecords.Repository;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;

namespace Hospital_API.ImplRepository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(MyDbContext context)
            : base(context)
        { 
        
        }
        public Patient GetByUniqueFields(string username, string email, string jmbg)
        {
            throw new System.NotImplementedException();
        }
    }
}

