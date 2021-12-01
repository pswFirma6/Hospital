using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplRepository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {

        public DoctorRepository(MyDbContext context)
            : base(context)
        {
        }

    }
}
