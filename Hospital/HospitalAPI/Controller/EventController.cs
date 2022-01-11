using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service.Implements;
using HospitalAPI.ImplRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService eventService;
        private IEventRepository eventRepository;
        public EventController(DatabaseEventContext context)
        {
            eventRepository = new EventRepository(context);
            eventService = new EventService();
        }

        [HttpPost]
        [Route("addEvent")]
        public void Add(String appName, String eventName)
        {
            eventService.CreateEventEntry(appName, eventName);
        }
    }
}
