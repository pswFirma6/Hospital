

using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;

using System;
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

            patient.Allergies = allergies;

            return patient;
        }

        public List<Patient> GetMaliciousPatients()
        {
            List<Patient> allPatients = _hospitalRepositoryFactory.GetPatientRepository().GetAll();

            foreach (Patient patient in allPatients)
            {
                var appointmentList = GetCancelledAppointmentsByPatient(patient.Id);

                foreach (Appointment appointment in appointmentList)
                {
                    if (appointment.AppointmentType != Hospital_library.MedicalRecords.Model.Enums.AppointmentType.Cancelled)
                    {
                        appointmentList.Remove(appointment);
                    }
                }

                if (appointmentList.Count > 2)
                {
                    if (appointmentList[appointmentList.Count - 3].StartTime > DateTime.Now.AddDays(-30))
                    {
                        patient.Malicious = true;
                    }
                }
            }
            return allPatients;
        }

        private List<Appointment> GetCancelledAppointmentsByPatient(string id)
        {
            return _hospitalRepositoryFactory.GetAppointmentsRepository().GetAll().Where(x => x.PatientId == id).ToList();
        }
    }
}
