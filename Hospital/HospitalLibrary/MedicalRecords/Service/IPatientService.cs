using Hospital_library.MedicalRecords.Model;
using System.Threading.Tasks;

namespace Hospital_library.MedicalRecords.Service
{
    public interface IPatientService
    {
        Patient Register(Patient patient);
        bool CheckExisting(Patient patient);
    }
}
