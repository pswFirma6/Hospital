using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Implements;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests
{
    class EventSourcingTest
    {
        /*
        [Theory]
        [MemberData(nameof(ExistingData))]
        public void Check_Existing_Doctor_Appointment(AppointmentEvent newAppointment1, AppointmentEvent newAppointment2)
        {
            //  Arrange  //
            EventService service = new EventService(CreateStubRepository());

            //  Act  //
            List<AppointmentEvent> exists1 = service.getAllUncreatedEvents();
            List<AppointmentEvent> exists2 = service.getAllUncreatedEvents();

            //  Assert  //
            Assert.True(exists1);
            Assert.True(exists2);
        }

        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();



            var dateString = "1/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);




            List<AppointmentEvent> appEvent = new List<AppointmentEvent>();
            appEvent.Add(1, "Four step create appointment", date, "AppForPatient", 24568.120, 22, false);


            stubRepository.Setup(m => m.GetEventRepository().GetEventsAll()).Returns(appEvent);

            return stubRepository.Object;
        }

        */
    }
}
