using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplService
{
    public class PatientService : IPatientService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;
        public PatientService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public bool CheckExisting(Patient patient)
        {
            var existingPatients = _hospitalRepositoryFactory.GetPatientRepository().GetAll();
            return existingPatients.Any(x => x.Username.Equals(patient.Username) || x.Email.Equals(patient.Email)
                || x.Jmbg.Equals(patient.Jmbg));

        }

        public Patient Register(Patient patient)
        {
            
            if (CheckExisting(patient) )
            {
                return null;
            }

            return _hospitalRepositoryFactory.GetPatientRepository().Add(MapAllergies(patient));
        }

        public Patient MapAllergies(Patient patient) 
        {
            List<Allergy> allergies = new List<Allergy>();
            foreach (var allergy in patient.Allergies) 
            {

                Allergy allergyFromDB = _hospitalRepositoryFactory.GetAllergyRepository().GetOne(allergy.Id);
                allergies.Add(allergyFromDB);

            }

            patient.Allergies = allergies;

            return patient;
        } 
    }
}
