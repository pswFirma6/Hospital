using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplService
{
    public class MedicineService : IMedicineService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public MedicineService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public void AddMedicine(Medicine medicine)
        {
            _hospitalRepositoryFactory.GetMedicineRepository().Add(medicine);
        }

        public List<Medicine> GetMedicines()
        {
            return _hospitalRepositoryFactory.GetMedicineRepository().GetAll();
        }

        public Medicine FindMedicine(int id)
        {
            return _hospitalRepositoryFactory.GetMedicineRepository().GetOne(id);
        }

        public Medicine EditMedicine(Medicine medicine)
        {
            Medicine med = _hospitalRepositoryFactory.GetMedicineRepository().GetOne(medicine.Id);
            med.Quantity = medicine.Quantity;
            return _hospitalRepositoryFactory.GetMedicineRepository().Update(med);
        }

        public void UrgentProcurement(Medicine medicine)
        {
            Medicine existingMedicine = CheckIfMedicineExists(medicine.Name);
            if (existingMedicine == null)
            {
                AddMedicine(medicine);
            }
            else
            {
                existingMedicine.Quantity += medicine.Quantity;
                EditMedicine(existingMedicine);
            }
        }

        public Medicine CheckIfMedicineExists(string medicineName)
        {
            foreach(Medicine medicine in GetMedicines())
            {
                if(medicine.Name == medicineName)
                {
                    return medicine;
                }
            }
            return null;
        }
    }
}
