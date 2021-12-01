using HospitalLibrary.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Service
{

    public interface IFeedbackService
    {
        void Add(Feedback feedback);
        List<ViewFeedback> GetAllApproved();
        List<Feedback> GetAll();
        void ChangeState(string id, string state);
    }
        
}
