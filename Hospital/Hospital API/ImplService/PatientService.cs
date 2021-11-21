
using Hospital_API.DTO;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using System.Linq;

namespace Hospital_API.ImplService
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public bool CheckExisting(Patient patient)
        {
            var existingPatients = _patientRepository.GetAll();
            return existingPatients.Any(x => x.Username.Equals(patient.Username) || x.Email.Equals(patient.Email)
                || x.Jmbg.Equals(patient.Jmbg));

        }

        public Patient Register(Patient patient)
        {
            if (CheckExisting(patient))
            {
                return null;
            }

            return _patientRepository.Add(patient);
        }
    }
}
