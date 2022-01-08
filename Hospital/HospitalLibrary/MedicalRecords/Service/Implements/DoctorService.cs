using Hospital_library.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplService
{
    public class DoctorService : IDoctorService
    {
        private readonly RepositoryFactory _repositoryFactory;

        public DoctorService(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public List<Doctor> GetSpecialists(DoctorType type)
        {
            return _repositoryFactory.GetDoctorsRepository().GetSpecialists(type);
        }

        public List<Doctor> GetAvailable()
        {
            List<Doctor> doctors = _repositoryFactory.GetDoctorsRepository().GetAll()
                .Where(x => x.DoctorType.Equals(DoctorType.generalPractitioner)).ToList();
            var minPatients = doctors.Select(x => x.Patients.Count).Min();
            return doctors.Where(x => x.Patients.Count <= minPatients + 2).ToList();
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _repositoryFactory.GetDoctorsRepository().GetAll();
            return doctors;
        }
    }
}
