using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
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

            if (CheckExisting(patient))
            {
                return null;
            }
            //patient.Id = _hospitalRepositoryFactory.GetPatientRepository().GetAll().Count + 1;
            return _hospitalRepositoryFactory.GetPatientRepository().Add(MapAllergies(patient));
        }
        public Patient GetPatient(int id)
        {
            return _hospitalRepositoryFactory.GetPatientRepository().GetOne(id);
        }
        public List<Patient> GetAllPatient()
        {
            return _hospitalRepositoryFactory.GetPatientRepository().GetAll();
        }

        public Patient MapAllergies(Patient patient)
        {
            List<Allergy> allergies = new List<Allergy>();
            foreach (var allergy in patient.Allergies)
            {

                Allergy allergyFromDB = _hospitalRepositoryFactory.GetAllergyRepository().GetOne(allergy.Id);
                allergies.Add(allergyFromDB);

            }

            patient.AddAllergiesToPatient(allergies);

            return patient;
        }

        public List<Patient> GetMaliciousPatients()
        {
            return _hospitalRepositoryFactory.GetPatientRepository().GetAll().Where(x => x.Malicious == true).ToList();
        }

        public void BlockPatient(Patient patient)
        {
            _hospitalRepositoryFactory.GetPatientRepository().GetOne(patient.Id).ChangePatientsBlockedStatus(true);
            _hospitalRepositoryFactory.GetPatientRepository().Update(patient);
        }

        public void UnblockPatient(Patient patient)
        {
            _hospitalRepositoryFactory.GetPatientRepository().GetOne(patient.Id).ChangePatientsBlockedStatus(false);
            _hospitalRepositoryFactory.GetPatientRepository().Update(patient);
        }

        public Patient GetPatientByUsername(string username) 
        {
            return _hospitalRepositoryFactory.GetPatientRepository().GetByUsername(username);
        }

        public void SetPatientMaliciousStatus(int id, bool status)
        {
            _hospitalRepositoryFactory.GetPatientRepository().SetPatientMaliciousStatus(id, status);
        }
    }
}
