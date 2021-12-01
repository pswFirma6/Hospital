using Hospital_library.MedicalRecords.Service;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalAPI.ImplService
{
    public class AllergyService : IAllergyService
    {
        private RepositoryFactory _hospitalRepositoryFactory;

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
