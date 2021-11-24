using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;

namespace HospitalAPI.ImplRepository
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

