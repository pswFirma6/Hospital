using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplService
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public PrescriptionService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public void AddPrescription(Prescription prescription)
        {
            prescription.Dosage.SetPrescriptionDate(DateTime.Now.ToString());
            _hospitalRepositoryFactory.GetPrescriptionRepository().Add(prescription);
        }

        public List<Prescription> GetPrescriptions()
        {
            return _hospitalRepositoryFactory.GetPrescriptionRepository().GetAll();
        }

        public void SendPrescription(PrescriptionDto prescription)
        {
            throw new NotImplementedException();
        }
    }
}
