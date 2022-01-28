using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Implements;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests
{
    public class ViewEventDataTest
    {
        [Fact]
        public void Check_Get_AllCompletedEventsTesd()
        {
            //  Arrange  //
            EventService service = new EventService(CreateStubRepository());

            //  Act  //
            List<AppointmentEvent> exists1 = service.getAllCompletedAppointmentEvents();
           

            //  Assert  //
            Assert.NotEmpty(exists1);
            Assert.Equal(1, exists1[0].DoctorId);
        }

        [Fact]
        public void Check_Get_AverageTimeEventsTesd()
        {
            //  Arrange  //
            EventService service = new EventService(CreateStubRepository());

            //  Act  //
            List<int> exists1 = service.getAverageTimePerEventStep();


            //  Assert  //
            Assert.NotEmpty(exists1);
            Assert.Equal(4, exists1[0]);
        }

        [Fact]
        public void Check_Get_Average_StepInstances_EventsTesd()
        {
            //  Arrange  //
            EventService service = new EventService(CreateStubRepository());

            //  Act  //
            List<double> exists1 = service.GetAverageStepTimes();


            //  Assert  //
            Assert.NotEmpty(exists1);
            Assert.Equal(8, exists1[0]);
        }
        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            var dateString1 = "1/14/2022 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);

            var dateString2 = "1/15/2022 8:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);

            EventStep eventStep1 = new EventStep();
            eventStep1.Id = 1;
            eventStep1.Name = "Date";
            eventStep1.TimeSpan = 5;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 1;

            EventStep eventStep2 = new EventStep();
            eventStep1.Id = 2;
            eventStep1.Name = "Specialization";
            eventStep1.TimeSpan = 2;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 1;

            EventStep eventStep3 = new EventStep();
            eventStep1.Id = 3;
            eventStep1.Name = "Doctor";
            eventStep1.TimeSpan = 3;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 1;

            EventStep eventStep4 = new EventStep();
            eventStep1.Id = 4;
            eventStep1.Name = "Term";
            eventStep1.TimeSpan = 10;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 1;

            EventStep eventStep5 = new EventStep();
            eventStep1.Id = 5;
            eventStep1.Name = "Date";
            eventStep1.TimeSpan = 5;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 2;

            EventStep eventStep6 = new EventStep();
            eventStep1.Id = 6;
            eventStep1.Name = "Specialization";
            eventStep1.TimeSpan = 2;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 2;

            EventStep eventStep7 = new EventStep();
            eventStep1.Id = 7;
            eventStep1.Name = "Doctor";
            eventStep1.TimeSpan = 3;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 2;

            EventStep eventStep8 = new EventStep();
            eventStep1.Id = 8;
            eventStep1.Name = "Term";
            eventStep1.TimeSpan = 10;
            eventStep1.ClickTime = date1;
            eventStep1.AppointmentEventId = 2;


            AppointmentEvent appointmentEvent1 = new AppointmentEvent();
            appointmentEvent1.Id = 1;
            appointmentEvent1.Name = "AddAppointment";
            appointmentEvent1.TimeSpan = 300;
            
            appointmentEvent1.ClickTime = date1;
            appointmentEvent1.DoctorId = 1;
            appointmentEvent1.AppointmentCreated = true;

            AppointmentEvent appointmentEvent2 = new AppointmentEvent();
            appointmentEvent1.Id = 2;
            appointmentEvent1.Name = "AddAppointment";
            appointmentEvent1.TimeSpan = 300;
           
            appointmentEvent1.ClickTime = date2;
            appointmentEvent1.DoctorId = 2;
            appointmentEvent1.AppointmentCreated = true;


            return stubRepository.Object;
        }
    }
}
