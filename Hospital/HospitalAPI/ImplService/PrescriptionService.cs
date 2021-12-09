using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplService
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;
        private readonly string integrationServer = "https://localhost:44317";

        public PrescriptionService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public void AddPrescription(Prescription prescription)
        {
            prescription.PrescriptionDate = new DateTime().ToString();
            _hospitalRepositoryFactory.GetPrescriptionRepository().Add(prescription);
        }

        public List<Prescription> GetPrescriptions()
        {
            return _hospitalRepositoryFactory.GetPrescriptionRepository().GetAll();
        }

        public void SendPrescription(Prescription prescription)
        {
            var client = new RestClient(integrationServer);
            var request = new RestRequest("/sendPrescription");
            request.AddJsonBody(prescription);
            var response = client.Post(request);
        }
    }
}
