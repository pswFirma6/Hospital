using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Repository;
using System.Linq;

namespace HospitalAPI.ImplRepository
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        private readonly MyDbContext _context;
        public ManagerRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }
        public Manager GetByLoginCredentials(string username, string password, UserType userType)
        {
            return _context.Managers.SingleOrDefault(m => m.Username == username && m.Password == password && m.UserType == userType);
        }
    }
}
