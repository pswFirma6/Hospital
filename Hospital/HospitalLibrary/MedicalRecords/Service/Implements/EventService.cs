using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_library.MedicalRecords.Service.Implements
{
    public class EventService : IEventService
    {
        private readonly RepositoryFactory _hospitalRepositoryFactory;

        public EventService(RepositoryFactory hospitalRepositoryFactory)
        {
            _hospitalRepositoryFactory = hospitalRepositoryFactory;
        }

        public AppointmentEvent CreateEventEntry(AppointmentEvent ev)
        {

            _hospitalRepositoryFactory.GetEventRepository().AddEvent(ev);
            
            return ev;
        }

        public EventStep CreateStepEventEntry(EventStep ev)
        {
            EventStep e = new EventStep();
            e.AppointmentEventId = ev.AppointmentEventId;
            e.ClickTime = DateTime.Now;
            e.Name = ev.Name;
            e.TimeSpan = ev.TimeSpan;

            _hospitalRepositoryFactory.GetEventStepRepository().AddEvent(e);

            return e;
        }
        
        public List<AppointmentEvent> getAllAppointmentEvents()
        {
            return _hospitalRepositoryFactory.GetEventRepository().GetEventsAll();
        }
        
        public List<AppointmentEvent> getAllCompletedAppointmentEvents()
        {
            List<AppointmentEvent> completedEventslist = new List<AppointmentEvent>();
            completedEventslist = _hospitalRepositoryFactory.GetEventRepository().GetEventsAll()
                        .Where(x => x.AppointmentCreated.Equals(true)).ToList();
            return completedEventslist;
        }

        public List<int> getAverageTimePerEventStep()
        {
            int countJan = 0;
            int countFeb = 0;
            int countMar = 0;
            int countApr = 0;
            int countMay = 0;
            int countJun = 0;
            int countJul = 0;
            int countAvg = 0;
            int countSep = 0;
            int countOct = 0;
            int countNov = 0;
            int countDec = 0;


            List<int> listOfAverages = new List<int>();

            List<AppointmentEvent> appointmentEvents = getAllCompletedAppointmentEvents();
            foreach (AppointmentEvent appEvent in appointmentEvents)
            {
                ICollection<EventStep> eventSteps = appEvent.EventsStep;
                foreach(EventStep step in eventSteps)
                {
                    if (step.ClickTime.Year.Equals(2021))
                    {
                        if (step.ClickTime.Month.Equals(1)){
                            countJan = CountInstanscesOfEventStep(step, countJan);
                        }
                        if (step.ClickTime.Month.Equals(2))
                        {
                            countFeb = CountInstanscesOfEventStep(step, countFeb);
                        }
                        if (step.ClickTime.Month.Equals(3))
                        {
                            countMar = CountInstanscesOfEventStep(step, countMar);
                        }
                        if (step.ClickTime.Month.Equals(4))
                        {
                            countApr = CountInstanscesOfEventStep(step, countApr);
                        }
                        if (step.ClickTime.Month.Equals(5))
                        {
                            countMay = CountInstanscesOfEventStep(step, countMay);
                        }
                        if (step.ClickTime.Month.Equals(6))
                        {
                            countJun = CountInstanscesOfEventStep(step, countJun);
                        }
                        if (step.ClickTime.Month.Equals(7))
                        {
                            countJul = CountInstanscesOfEventStep(step, countJul);
                        }
                        if (step.ClickTime.Month.Equals(8))
                        {
                            countAvg = CountInstanscesOfEventStep(step, countAvg);
                        }
                        if (step.ClickTime.Month.Equals(9))
                        {
                            countSep = CountInstanscesOfEventStep(step, countSep);
                        }
                        if (step.ClickTime.Month.Equals(10))
                        {
                            countOct = CountInstanscesOfEventStep(step, countOct);
                        }
                        if (step.ClickTime.Month.Equals(11))
                        {
                            countNov = CountInstanscesOfEventStep(step, countNov);
                        }
                        if (step.ClickTime.Month.Equals(12))
                        {
                            countDec = CountInstanscesOfEventStep(step, countDec);
                        }



                    }
                }
            }
            listOfAverages.Add(countJan);
            listOfAverages.Add(countFeb);
            listOfAverages.Add(countMar);
            listOfAverages.Add(countApr);
            listOfAverages.Add(countMay);
            listOfAverages.Add(countJun);
            listOfAverages.Add(countJul);
            listOfAverages.Add(countAvg);
            listOfAverages.Add(countSep);
            listOfAverages.Add(countOct);
            listOfAverages.Add(countNov);
            listOfAverages.Add(countDec);

            return listOfAverages;
        }

        public int CountInstanscesOfEventStep(EventStep step , int count)
        {
            if (step.Name.Equals("Date")) { return CountMonthsInEventStep(step, count); }
            if (step.Name.Equals("Speciality")) { return CountMonthsInEventStep(step, count); }
            if (step.Name.Equals("Doctor")) { return CountMonthsInEventStep(step, count); }
            if (step.Name.Equals("Term")) { return CountMonthsInEventStep(step, count); }
            else return -1;
        }

        public int CountMonthsInEventStep(EventStep step , int count)
        {
            if (step.ClickTime.Month.Equals(1)) { return ++count; }
            else if (step.ClickTime.Month.Equals(2)) { return ++count; }
            else if (step.ClickTime.Month.Equals(3)) { return ++count; }
            else if (step.ClickTime.Month.Equals(4)) { return ++count; }
            else if (step.ClickTime.Month.Equals(5)) { return ++count; }
            else if (step.ClickTime.Month.Equals(6)) { return ++count; }
            else if (step.ClickTime.Month.Equals(7)) { return ++count; }
            else if (step.ClickTime.Month.Equals(8)) { return ++count; }
            else if (step.ClickTime.Month.Equals(9)) { return ++count; }
            else if (step.ClickTime.Month.Equals(10)) { return ++count; }
            else if (step.ClickTime.Month.Equals(11)) { return ++count; }
            else if (step.ClickTime.Month.Equals(12)) { return ++count; }
            else return count = -1;

        }

        public List<double> GetAverageStepTimes()
        {
            double countDate = 0;
            double countSpeciality = 0;
            double countDoctor = 0;
            double countTerm = 0;

            double timeDate = 0;
            double timeSpeciality = 0;
            double timeDoctor = 0;
            double timeTerm = 0;
                   
            double avgDate = 0;
            double avgSpeciality = 0;
            double avgDoctor = 0;
            double avgTerm = 0;

            List<double> listAverageStepTime = new List<double>();
            List<AppointmentEvent> appointmentEvents = getAllCompletedAppointmentEvents();
            foreach (AppointmentEvent appEvent in appointmentEvents)
            {
                ICollection<EventStep> eventSteps = appEvent.EventsStep;
                foreach (EventStep step in eventSteps)
                {

                    if (step.Name.Equals("Date"))
                    {
                        countDate++;
                        timeDate += step.TimeSpan;
                    }
                    if (step.Name.Equals("Speciality"))
                    {
                        countSpeciality++;
                        timeSpeciality += step.TimeSpan;
                    }
                    if (step.Name.Equals("Doctor"))
                    {
                        countDoctor++;
                        timeDoctor += step.TimeSpan;
                    }
                    if (step.Name.Equals("Term"))
                    {
                        countTerm++;
                        timeTerm += step.TimeSpan;
                    }
                    
                }   
            }
            avgDate = timeDate / countDate;
            avgSpeciality = timeSpeciality / countSpeciality;
            avgDoctor = timeDoctor / countDoctor;
            avgTerm = timeTerm / countTerm;

            listAverageStepTime.Add(avgDate);
            listAverageStepTime.Add(avgSpeciality);
            listAverageStepTime.Add(avgDoctor);
            listAverageStepTime.Add(avgTerm);

            return listAverageStepTime;
        }
    }
}
