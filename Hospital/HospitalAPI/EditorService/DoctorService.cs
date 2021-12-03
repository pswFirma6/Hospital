using HospitalAPI.EditorRepository;
using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.EditorService
{
    public class DoctorService : IService<Doctor>
    {
        private MyDbContext dbContxt;

        public DoctorService(MyDbContext dbContxt)
        {
            this.dbContxt = dbContxt;
        }

        public IEnumerable<Doctor> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt)) 
            {
                return unitOfWork.Doctors.GetAll();
            }
        }

        public Doctor create(Doctor doctor)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(dbContxt))
            {
                unitOfWork.Doctors.Add(doctor);
                unitOfWork.Complete();

                return doctor;
            }
        }
    }
}
