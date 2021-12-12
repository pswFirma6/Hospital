using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.ImplRepository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly MyDbContext _context;
        public DoctorRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Doctor> GetSpecialists(DoctorType type) 
        {
            return _context.Doctors.Where(x => x.DoctorType.Equals(type)).ToList();
        }
    }
}
