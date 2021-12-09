using Hospital_library.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IPrescriptionRepository
    {
        Prescription Add(Prescription prescription);
        List<Prescription> GetAll();
    }
}
