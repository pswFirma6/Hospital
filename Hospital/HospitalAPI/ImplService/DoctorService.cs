using Hospital_library.MedicalRecords.Service;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplService
{
    public class DoctorService : IDoctorService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public DoctorService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public void Create(Doctor doctor)
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAvailable()
        {
            List<Doctor> doctors = _hospitalRepositoryFactory.GetDoctorsRepository().GetAll()
                .Where(x => x.DoctorType.Equals(DoctorType.generalPractitioner)).ToList();
            var minPatients = doctors.Select(x => x.Patients.Count).Min();
            return doctors.Where(x => x.Patients.Count <= minPatients + 2).ToList();
        }
    }
}
