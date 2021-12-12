using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository.Interface
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        Feedback Add(Feedback feedback);
        Feedback GetOne(int id);
        Feedback Update(Feedback feedback);
    }
}
