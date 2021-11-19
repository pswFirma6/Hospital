﻿using Hospital_API.ImplRepository;
using Hospital_library.MedicalRecords.Repository;
using Hospital_library.MedicalRecords.Repository.Interface;


namespace Hospital_API.Repository
{
    public class HospitalRepositoryFactory : RepositoryFactory
    {
        private MyDbContext _context;
        public HospitalRepositoryFactory(MyDbContext context)
        {
            _context = context;
        }
        public FeedbackRepository FeedbackRepository { get; set; }
        public PatientRepository PersonRepository { get; set; }

        public override FeedbackRepository GetFeedbackRepository()
        {
            if (FeedbackRepository == null)
                return new FeedbackRepository(_context);
            else
                return FeedbackRepository;
        }

        public override PatientRepository GetPatientRepository()
        {
            if (PersonRepository == null)
                return new PatientRepository(_context);
            else
                return PersonRepository;
        }

    }
}
