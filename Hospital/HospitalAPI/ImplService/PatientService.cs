

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
            
            Patient patient = _patientRepository.GetOne(id);
            return patient;
        }
        public List<Patient> GetAllPatient()
        {
            return _patientRepository.GetAll();
        }
    }
}
