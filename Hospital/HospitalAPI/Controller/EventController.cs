using AutoMapper;
using Hospital_library.MedicalRecords.Model.Events;
using Hospital_library.MedicalRecords.Service.Interfaces;
using HospitalAPI.DTO.EventDTO;
using HospitalAPI.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        private readonly EventValidation _eventValidation;
        private readonly IMapper _mapper;
        public EventController(IEventService eventService, EventValidation eventValidation, IMapper mapper)
        {
            _eventService = eventService;
            _eventValidation = eventValidation;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addEvent")]
        public IActionResult AddEvent([FromBody] EventAppointmentDTO eventDTO)
        {
            if (!_eventValidation.IsValid(eventDTO)) 
            {
                return BadRequest();
            }

            var model = _mapper.Map<AppointmentEvent>(eventDTO);

            return Ok(_eventService.CreateEventEntry(model));
        }
        
        [HttpPost]
        [Route("addEventStep")]
        public IActionResult AddEventStep([FromBody] EventStepDTO eventStepDTO)
        {
            if (!_eventValidation.IsValidStep(eventStepDTO))
            {
                return BadRequest();
            }

            var model = _mapper.Map<EventStep>(eventStepDTO);

            return Ok(_eventService.CreateStepEventEntry(model));
        }

        [HttpGet]
        [Route("getAllEvents")]
        public IActionResult GetAllEvents()
        {
            List<AppointmentEvent> appointmentEvents = _eventService.getAllAppointmentEvents();
            return Ok(appointmentEvents);
        }

        [HttpGet]
        [Route("getStepsPerDate")]
        public IActionResult GetTimePerStep()
        {
            List<int> appointmentEvents = _eventService.getAverageTimePerEventStep();
            return Ok(appointmentEvents);
        }

        [HttpGet]
        [Route("getAverageStepTime")]
        public IActionResult GetAverageStepTime()
        {
            List<double> appointmentEvents = _eventService.GetAverageStepTimes();
            return Ok(appointmentEvents);
        }

    }
}
