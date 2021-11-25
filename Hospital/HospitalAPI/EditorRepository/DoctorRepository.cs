using HospitalLibrary.GraphicalEditor.Core;
using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorRepository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(MyDbContext context) : base(context)
        {

        }
    }
}
