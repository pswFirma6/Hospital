using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;

namespace HospitalAPI.ImplRepository
{
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        public AllergyRepository(MyDbContext context)
            : base(context)
        {
        }
    }
}
