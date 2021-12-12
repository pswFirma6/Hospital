using HospitalLibrary.MedicalRecords.Model;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
