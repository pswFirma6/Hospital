using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System.Collections.Generic;

namespace HospitalAPI.ImplService
{
    public class AllergyService : IAllergyService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public AllergyService(RepositoryFactory hospitalRepositoryFactory) 
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public List<Allergy> GetAllergies()
        {
            return _hospitalRepositoryFactory.GetAllergyRepository().GetAll();
        }
    }
}
