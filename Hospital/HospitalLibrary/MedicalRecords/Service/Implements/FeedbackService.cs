using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Service
{

    public class FeedbackService : IFeedbackService
    {
        public RepositoryFactory _repositoryFactory;

        public FeedbackService(RepositoryFactory repositoryFactory) 
        {
            _repositoryFactory = repositoryFactory;
        }

        public List<ViewFeedback> GetAllApproved()
        {
         
            List<Feedback> feedbacks = _repositoryFactory.GetFeedbackRepository().GetAll();
            List<Patient> patients = _repositoryFactory.GetPatientRepository().GetAll();
            List<ViewFeedback> feedbackDTOs = new List<ViewFeedback>();

            foreach (Feedback feedback in feedbacks)
            {
                Patient patient = patients.Find(id => id.Id == feedback.PersonId);
                if (feedback.Information.State == FeedbackState.approved)
                {
                    if (feedback.Anonymous)
                    {
                        feedbackDTOs.Add(new ViewFeedback("Anonymous", feedback.Information.Text, feedback.Information.Date));
                    }
                    else
                    {
                        feedbackDTOs.Add(new ViewFeedback(patient.Name + " " + patient.Surname, feedback.Information.Text, feedback.Information.Date));
                    }
                }
            }
            return feedbackDTOs;
        }

        public void Add(Feedback feedback)
        {
            if (feedback.Date == null)
            {
                feedback.Date = DateTime.Now;
            }
            feedback.Id = _repositoryFactory.GetFeedbackRepository().GetAll().Count + 1;
            _repositoryFactory.GetFeedbackRepository().Add(feedback);
        }

        /*public List<FeedbackWithUsernameDTO> GetAll()
        {
            List<Feedback> feedbacks = _repositoryFactory.GetFeedbackRepository().GetAll();
            List<FeedbackWithUsernameDTO> feedbacksWithUsernameDTOs = new List<FeedbackWithUsernameDTO>();
            List<Person> persons = _repositoryFactory.GetPersonRepository().GetAll();

            foreach (Feedback feedback in feedbacks)
            {
                Person person = persons.Find(id => id.Id == feedback.PersonId);
                feedbacksWithUsernameDTOs.Add(new FeedbackWithUsernameDTO(person.Username, feedback.Text, feedback.Date,
                    feedback.State, feedback.Anonymous, feedback.Publish));
            }

            return feedbacksWithUsernameDTOs;
        }*/
        public List<Feedback> GetAll()
        {
            List<Feedback> feedbacks = _repositoryFactory.GetFeedbackRepository().GetAll();
            return feedbacks;
        }

        public void ChangeState(int id, string state)
        {
            Feedback feedback = _repositoryFactory.GetFeedbackRepository().GetOne(id);
            switch (state)
            {
                case "approved":
                    feedback.State = FeedbackState.approved;
                    break;
                case "rejected":
                    feedback.State = FeedbackState.rejected;
                    break;
                case "pending":
                    feedback.State = FeedbackState.pending;
                    break;
            }
            _repositoryFactory.GetFeedbackRepository().Update(feedback);
        }
    }

}
