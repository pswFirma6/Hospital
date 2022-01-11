using Hospital_library.MedicalRecords.Service.Implements;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests
{
    public class LoginTest
    {
        [Theory]
        [MemberData(nameof(ExistingData))]
        public void Authenticate_User_Successfully(User userInfo)
        {
            //  Arrange  //
            LoginService service = new LoginService(CreateStubRepository());

            //  Act  //
            User user = service.AuthenticateUser(userInfo);

            //  Assert  //
            Assert.Equal(user.Username, userInfo.Username);
            Assert.Equal(user.Password, userInfo.Password);
            Assert.True(user.Activated);
        }


        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();

            Patient patient = new Patient(4, "Monika", "Beluci", DateTime.Now,
                "054236971333", "Partizanskih baza 8.", "0666423699", "seve@gmail.com",
                "Monika", "pacijent123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, true, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor);


            stubRepository.Setup(m => m.GetPatientRepository().GetByLoginCredentials(patient.Username, patient.Password, patient.UserType)).Returns(patient);

            return stubRepository.Object;
        }

        public static IEnumerable<object[]> ExistingData()
        {
            var retVal = new List<object[]>();

            User user = new User( "Monika", "pacijent123", UserType.patient );

            retVal.Add(new object[] { user });

            return retVal;
        }
    }
}
