using AutoMapper;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.ImplService
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
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

            Patient newPatient = _patientRepository.Add(patient);

            return newPatient;
        }
    }
}
