using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.ImplRepository
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(MyDbContext context)
            : base(context)
        { }
    }
}
