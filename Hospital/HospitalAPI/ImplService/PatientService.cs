

using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Model.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplService
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
        public Patient GetPatient(string id)
        {
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            List<Allergy> allergies = new List<Allergy>();

            Patient newPatientA1 = new Patient("2", "Slavko", "Vranjes", DateTime.Now,
                "054236971333", "Partizanskih baza 8.", "0666423699", "slavko@gmail.com",
                "slavko", "slavko123", Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, doctor, allergies);

            _patientRepository.Add(newPatientA1);
            return _patientRepository.GetOne(id);
        }
    }
}
