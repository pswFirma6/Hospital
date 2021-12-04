using Hospital_library.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IMedicineService
    {
        List<Medicine> GetMedicines();
        void AddMedicine(Medicine medicine);
        Medicine FindMedicine(int id);
        Medicine EditMedicine(Medicine medicine);
        void UrgentProcurement(Medicine medicine);
        Medicine CheckIfMedicineExists(string medicineName);
    }
}
