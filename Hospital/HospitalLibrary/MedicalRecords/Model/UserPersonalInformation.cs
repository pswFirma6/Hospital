using HospitalLibrary.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class UserPersonalInformation : ValueObject
    {
        public int UserPersInfId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Jmbg { get; private set; }
        public Gender Gender { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return BirthDate;
            yield return Jmbg;
            yield return Gender;
        }

        public UserPersonalInformation(int userPersInfId, string name, string surname, DateTime birthDate, string jmbg, Gender gender)
        {
            UserPersInfId = userPersInfId;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Jmbg = jmbg;
            Gender = gender;
        }
    }
}
