﻿using HospitalAPI.DTO;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Service
{

    public class FeedbackService : IFeedbackService
    {
        public HospitalRepositoryFactory _repositoryFactory;

        public FeedbackService(HospitalRepositoryFactory repositoryFactory, MyDbContext aa) 
        {
            _repositoryFactory = repositoryFactory;
        }

        public List<ViewFeedbackDTO> GetAllApproved()
        {
          /* Person person1 = new Person
            ( 
                "1",
                "Marko",
                "Markovic",
                new DateTime(2012,12,25),
                "213122121",
                "Aaaaaaaaa",
                "aaaaaaaaaaaa",
                "aaaaaaaaaaaa",
                "aaaaaaaaaaaa",
                "aaaaaaaaaaaa",
                Hospital_library.Model.Enumeration.Gender.male
           );

            _repositoryFactory.GetPersonRepository().Add(person1);
            */
            List<Feedback> feedbacks = _repositoryFactory.GetFeedbackRepository().GetAll();
            List<Patient> patients = _repositoryFactory.GetPatientRepository().GetAll();
            List<ViewFeedbackDTO> feedbackDTOs = new List<ViewFeedbackDTO>();

            foreach (Feedback feedback in feedbacks)
            {
                Patient patient = patients.Find(id => id.Id == feedback.PersonId);
                if (feedback.State == FeedbackState.approved)
                {
                    if (feedback.Anonymous)
                    {
                        feedbackDTOs.Add(new ViewFeedbackDTO("Anonymous", feedback.Text, feedback.Date));
                    }
                    else
                    {
                        feedbackDTOs.Add(new ViewFeedbackDTO(patient.Name + " " + patient.Surname, feedback.Text, feedback.Date));
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

        public void ChangeState(string id, string state)
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