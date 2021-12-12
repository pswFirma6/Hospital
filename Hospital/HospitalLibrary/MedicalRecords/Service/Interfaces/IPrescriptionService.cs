using Hospital_library.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IPrescriptionService
    {
        List<Prescription> GetPrescriptions();
        void AddPrescription(Prescription prescription);

        public void SendPrescription(PrescriptionDto prescription);

    }
}
